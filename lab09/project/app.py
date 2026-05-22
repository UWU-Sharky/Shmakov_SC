from collections import Counter, deque, defaultdict
import math
import random
from flask import Flask, request, jsonify, render_template

app = Flask(__name__)

def ExpRV(lambd):
    return -math.log(1 - random.random()) / lambd

def simulate_MM1_queue(lambd, mu, N, T_total):
    current_time = 0
    serving_client = 0
    queue = 0
    
    waiting_times = []
    state_durations = defaultdict(float) # Сколько времени система провела с 'k' клиентами внутри
    
    # Очередь, где хранятся моменты времени (timestamps) прихода клиентов
    arrival_timestamps = deque()
    
    while current_time < T_total:
        time_next_client = ExpRV(lambd)
        if serving_client > 0:
            client_exit = ExpRV(mu * serving_client)
        else:
            client_exit = float('inf')
          
        if time_next_client < client_exit:
            dt = time_next_client
            is_arrival = True
        else:
            dt = client_exit
            is_arrival = False
        
        total_clients_now = serving_client + queue
        state_durations[total_clients_now] += dt

        current_time += dt
        
        if is_arrival:
            if serving_client < N:
                serving_client += 1
                waiting_times.append(0.0)  # Оператор свободен, время ожидания = 0
            else:
                queue += 1
                arrival_timestamps.append(current_time)  # Запоминаем время входа в очередь
        else:
            if queue == 0:
                serving_client -= 1
            else:
                queue -= 1
                # Клиент выходит из очереди к освободившемуся оператору
                if arrival_timestamps:
                    arrival_time = arrival_timestamps.popleft()
                    wait_time = current_time - arrival_time
                    waiting_times.append(wait_time)
    
    for k in range(len(state_durations)):
        state_durations[k] /= T_total

    avg_wait = sum(waiting_times) / len(waiting_times)
    avg_clients = sum(k * v for k, v in state_durations.items()) / T_total
    avg_queue = sum(k * v for k, v in state_durations.items() if k > 0) / T_total
    rho = lambd / (mu * N) 
    
    return {
        "states": dict(state_durations),
        "waiting_times": waiting_times,
        "statistics": {
        "avg_wait": avg_wait,
        "avg_clients": avg_clients,
        "avg_queue": avg_queue,
        "rho": rho,
            }
    }


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/simulate', methods=['POST'])
def simulate():

    data = request.get_json()

    lambd = float(data['lambda'])
    mu = float(data['mu'])
    N = int(data['N'])
    T_total = float(data['T'])

    result = simulate_MM1_queue(lambd, mu, N, T_total)

    return jsonify(result)


if __name__ == '__main__':
    app.run(debug=True)
