import random
import math

def ExpRV(lambd):
    return -math.log(1 - random.random()) / lambd

class Client:
    def __init__(self, client_id, current_time, max_patience):
        self.id = client_id
        self.arrival_time = current_time
        self.abandon_time = current_time + max_patience 
        self.state = "in_queue" 
        self.wait_time = 0

    def get_next_event(self):
        # Клиент сам инициирует событие потери терпения, только если он находится в очереди
        if self.state == "in_queue":
            return self.abandon_time
        return math.inf

    def process_event(self, bank):
        # Клиент устал ждать в очереди и уходит
        if self.state == "in_queue":
            self.state = "abandoned"
            bank.queue.remove(self)
            bank.stats['abandoned'] += 1

class Operator:
    def __init__(self, operator_id):
        self.id = operator_id
        self.state = "free"
        self.finish_time = math.inf
        self.current_client = None

    def get_next_event(self):
        return self.finish_time

    def process_event(self, bank):
        # Завершение обслуживания текущего клиента
        self.state = "free"
        self.finish_time = math.inf
        if self.current_client:
            self.current_client.state = "completed"
            bank.stats['completed'] += 1
            self.current_client = None
        
        # Если в очереди есть клиенты, сразу берем следующего на обслуживание
        if bank.queue:
            next_client = bank.queue.pop(0)
            bank.start_service(self, next_client)

class Generator:
    def __init__(self, arrival_rate):
        self.arrival_rate = arrival_rate
        self.next_arrival_time = ExpRV(self.arrival_rate)
        self.client_counter = 0

    def get_next_event(self):
        return self.next_arrival_time

    def process_event(self, bank):
        self.client_counter += 1
        # Рассчитываем индивидуальное терпение клиента
        patience = ExpRV(bank.patience_rate) if bank.patience_rate > 0 else math.inf
        new_client = Client(self.client_counter, bank.time, patience)
        
        bank.handle_new_client(new_client)
        
        # Планируем время прибытия следующего клиента
        self.next_arrival_time = bank.time + ExpRV(self.arrival_rate)

class BankSystem:
    def __init__(self, num_operators, max_queue, arrival_rate, service_rate, patience_rate):
        self.time = 0.0
        self.queue = []
        self.max_queue = max_queue
        self.service_rate = service_rate
        self.patience_rate = patience_rate
        
        self.generator = Generator(arrival_rate)
        self.operators = [Operator(i) for i in range(num_operators)]
        self.active_clients = []
        
        self.time_in_queue = [0.0] * (max_queue + 1)
        self.time_in_ops = [0.0] * (num_operators + 1)
        
        self.stats = {
            'completed': 0, 
            'abandoned': 0, 
            'rejected_queue_full': 0,
            'queue_length_history': [], 
            'busy_operators_history': [], 
            'wait_times': []
        }

    def handle_new_client(self, client):
        self.active_clients.append(client)
        
        # Поиск свободного оператора
        free_operators = [op for op in self.operators if op.state == "free"]
        
        if free_operators:
            self.start_service(free_operators[0], client)
        elif len(self.queue) < self.max_queue:
            self.queue.append(client)
        else:
            client.state = "rejected"
            self.stats['rejected_queue_full'] += 1

    def start_service(self, operator, client):
        client.state = "in_service"
        client.wait_time = self.time - client.arrival_time
        self.stats['wait_times'].append(client.wait_time)
        
        operator.state = "busy"
        operator.current_client = client
        operator.finish_time = self.time + ExpRV(self.service_rate)

    def record_state(self):
        self.stats['queue_length_history'].append(len(self.queue))
        busy_count = sum(1 for op in self.operators if op.state == "busy")
        self.stats['busy_operators_history'].append(busy_count)

    def run(self, max_time):
        while self.time < max_time:
            # Оставляем в списке только тех клиентов, которые все еще ждут в очереди
            self.active_clients = [c for c in self.active_clients if c.state == "in_queue"]
            all_agents = [self.generator] + self.operators + self.active_clients
            
            # Находим ближайшее событие среди всех агентов
            t_min = math.inf
            active_agent = None
            
            for agent in all_agents:
                t_i = agent.get_next_event()
                if t_i < t_min:
                    t_min = t_i
                    active_agent = agent
                    
            # Обработка выхода за границы времени или отсутствия событий
            if t_min == math.inf or t_min > max_time:
                delta_t = max_time - self.time
                if delta_t > 0:
                    current_q_len = len(self.queue)
                    current_busy_ops = sum(1 for op in self.operators if op.state == "busy")
                    
                    self.time_in_queue[current_q_len] += delta_t
                    self.time_in_ops[current_busy_ops] += delta_t
                self.time = max_time
                break
                
            delta_t = t_min - self.time
            if delta_t > 0:
                current_q_len = len(self.queue)
                current_busy_ops = sum(1 for op in self.operators if op.state == "busy")
                
                # Прибавляем длительность интервала к текущим состояниям
                self.time_in_queue[current_q_len] += delta_t
                self.time_in_ops[current_busy_ops] += delta_t
            
            # Продвигаем стрелку модельного времени
            self.time = t_min
            
            # Запись мгновенного снимка истории
            self.record_state()
            
            # Обработка события активным агентом
            active_agent.process_event(self)