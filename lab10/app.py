import tkinter as tk
from tkinter import ttk, messagebox
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import numpy as np
from scipy import stats
from Bank_app import BankSystem

class BankSimulationGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("Агентное моделирование СМО M/M/*")
        self.root.geometry("1200x800")
        
        style = ttk.Style()
        style.theme_use('clam')
        
        self.create_input_frame()
        
        self.create_results_frame()
        
        self.create_plots_frame()
        
    def create_input_frame(self):
        input_frame = ttk.LabelFrame(self.root, text="Параметры моделирования", padding=10)
        input_frame.pack(fill=tk.X, padx=10, pady=5)
        
        params = [
            ("Количество операторов:", "num_ops", 2),
            ("Максимальная длина очереди:", "max_queue", 10),
            ("Интенсивность входящего потока:", "arr_rate", 0.8),
            ("Интенсивность обслуживания:", "srv_rate", 1.0),
            ("Интенсивность терпения:", "pat_rate", 0.5),
            ("Время моделирования:", "time_limit", 1000.0)
        ]
        
        self.entries = {}
        for i, (label, key, default) in enumerate(params):
            ttk.Label(input_frame, text=label).grid(row=i, column=0, sticky=tk.W, padx=5, pady=5)
            entry = ttk.Entry(input_frame, width=15)
            entry.insert(0, str(default))
            entry.grid(row=i, column=1, padx=5, pady=5)
            self.entries[key] = entry
        
        self.run_button = ttk.Button(input_frame, text="Запустить моделирование", 
                                     command=self.run_simulation)
        self.run_button.grid(row=len(params), column=0, columnspan=2, pady=10)
        
    def create_results_frame(self):
        # Фрейм для результатов
        results_frame = ttk.LabelFrame(self.root, text="Результаты моделирования", padding=10)
        results_frame.pack(fill=tk.X, padx=10, pady=5)
        
        # Таблица результатов
        self.results_tree = ttk.Treeview(results_frame, columns=("value",), height=5, show="tree headings")
        self.results_tree.heading("#0", text="Показатель")
        self.results_tree.heading("value", text="Значение")
        
        # Добавляем показатели
        metrics = [
            "Вероятность обслуживания",
            "Вероятность отказа",
            "Средняя длина очереди",
            "Среднее время ожидания",
            "Обслужено клиентов",
            "Ушедших из очереди",
            "Отклоненных (очередь полна)"
        ]
        
        for metric in metrics:
            self.results_tree.insert("", "end", text=metric, values=("—",))
        
        self.results_tree.pack(fill=tk.X, padx=5, pady=5)
        
    def create_plots_frame(self):
        # Фрейм для графиков
        plots_frame = ttk.LabelFrame(self.root, text="Графики", padding=10)
        plots_frame.pack(fill=tk.BOTH, expand=True, padx=10, pady=5)
        
        # Создаем Notebook для вкладок
        self.notebook = ttk.Notebook(plots_frame)
        self.notebook.pack(fill=tk.BOTH, expand=True)
        
        # Вкладка 1: Число занятых приборов
        self.busy_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.busy_frame, text="Число занятых приборов")
        
        # Вкладка 2: Длина очереди
        self.queue_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.queue_frame, text="Длина очереди")
        
        # Вкладка 3: Распределение времени ожидания
        self.wait_frame = ttk.Frame(self.notebook)
        self.notebook.add(self.wait_frame, text="Распределение времени ожидания")
        
        # Инициализация графиков
        self.init_plots()
        
    def init_plots(self):
        # График 1: Число занятых приборов
        self.fig1, self.ax1 = plt.subplots(figsize=(8, 4))
        self.canvas1 = FigureCanvasTkAgg(self.fig1, self.busy_frame)
        self.canvas1.get_tk_widget().pack(fill=tk.BOTH, expand=True)
        
        # График 2: Длина очереди
        self.fig2, self.ax2 = plt.subplots(figsize=(8, 4))
        self.canvas2 = FigureCanvasTkAgg(self.fig2, self.queue_frame)
        self.canvas2.get_tk_widget().pack(fill=tk.BOTH, expand=True)
        
        # График 3: Распределение времени ожидания
        self.fig3, self.ax3 = plt.subplots(figsize=(8, 4))
        self.canvas3 = FigureCanvasTkAgg(self.fig3, self.wait_frame)
        self.canvas3.get_tk_widget().pack(fill=tk.BOTH, expand=True)
        
    def run_simulation(self):
        try:
            # Получаем параметры
            params = {
                'num_ops': int(self.entries['num_ops'].get()),
                'max_queue': int(self.entries['max_queue'].get()),
                'arr_rate': float(self.entries['arr_rate'].get()),
                'srv_rate': float(self.entries['srv_rate'].get()),
                'pat_rate': float(self.entries['pat_rate'].get()),
                'time_limit': float(self.entries['time_limit'].get())
            }
            
            # Запускаем моделирование
            model = BankSystem(
                num_operators=params['num_ops'],
                max_queue=params['max_queue'],
                arrival_rate=params['arr_rate'],
                service_rate=params['srv_rate'],
                patience_rate=params['pat_rate']
            )
            
            model.run(params['time_limit'])
            
            # Вычисляем метрики
            served = model.stats['completed']
            abandoned = model.stats['abandoned']
            rejected = model.stats['rejected_queue_full']
            total_arrivals = served + abandoned + rejected
            
            p_serve = served / total_arrivals if total_arrivals > 0 else 0.0
            p_drop = (abandoned + rejected) / total_arrivals if total_arrivals > 0 else 0.0
            
            # Средняя длина очереди
            avg_q_len = sum(q * t for q, t in enumerate(model.time_in_queue)) / params['time_limit']
            
            # Среднее время ожидания
            wait_times = model.stats['wait_times']
            avg_wait = sum(wait_times) / len(wait_times) if wait_times else 0.0
            
            # Обновляем таблицу результатов
            results_values = [
                f"{p_serve:.4f}",
                f"{p_drop:.4f}",
                f"{avg_q_len:.4f}",
                f"{avg_wait:.4f}",
                str(served),
                str(abandoned),
                str(rejected)
            ]
            
            for i, item in enumerate(self.results_tree.get_children()):
                self.results_tree.item(item, values=(results_values[i],))
            
            # Обновляем графики
            self.update_plots(model, params)
            
        except Exception as e:
            messagebox.showerror("Ошибка", f"Ошибка при моделировании:\n{str(e)}")
            
    def update_plots(self, model, params):
        # Очищаем графики
        self.ax1.clear()
        self.ax2.clear()
        self.ax3.clear()
        
        # График 1: Распределение числа занятых приборов
        num_operators = params['num_ops']
        busy_probs = []
        for i in range(num_operators + 1):
            prob = model.time_in_ops[i] / params['time_limit']
            busy_probs.append(prob)
        
        x1 = range(num_operators + 1)
        self.ax1.bar(x1, busy_probs, alpha=0.7, color='steelblue')
        self.ax1.set_xlabel('Число занятых приборов')
        self.ax1.set_ylabel('Доля времени')
        self.ax1.set_title('Распределение числа занятых приборов')
        self.ax1.grid(True, alpha=0.3)
        self.ax1.set_xticks(x1)
        
        # Добавляем значения на столбцы
        for i, (x, prob) in enumerate(zip(x1, busy_probs)):
            if prob > 0.01:
                self.ax1.text(x, prob + 0.01, f'{prob:.3f}', ha='center', fontsize=9)
        
        self.canvas1.draw()
        
        # График 2: Распределение длины очереди
        queue_probs = []
        max_q = len(model.time_in_queue)
        for i in range(min(max_q, 21)):  # Показываем до 21 значения
            prob = model.time_in_queue[i] / params['time_limit']
            queue_probs.append(prob)
        
        x2 = range(len(queue_probs))
        self.ax2.bar(x2, queue_probs, alpha=0.7, color='coral')
        self.ax2.set_xlabel('Длина очереди')
        self.ax2.set_ylabel('Доля времени')
        self.ax2.set_title('Распределение длины очереди')
        self.ax2.grid(True, alpha=0.3)
        
        # Добавляем значения на столбцы
        for i, (x, prob) in enumerate(zip(x2, queue_probs)):
            if prob > 0.01:
                self.ax2.text(x, prob + 0.01, f'{prob:.3f}', ha='center', fontsize=9)
        
        self.canvas2.draw()
        
        # График 3: Гистограмма времени ожидания
        wait_times = model.stats['wait_times']
        if wait_times:
            # Создаем гистограмму
            n, bins, patches = self.ax3.hist(wait_times, bins=30, alpha=0.7, color='forestgreen', edgecolor='black', linewidth=0.5)
            
            # Кривая плотности 
            if len(wait_times) > 1:
                kde = stats.gaussian_kde(wait_times)
                x_range = np.linspace(min(wait_times), max(wait_times), 100)
                y_range = kde(x_range) * len(wait_times) * (bins[1] - bins[0])
                self.ax3.plot(x_range, y_range, 'r-', linewidth=2, label='Плотность распределения')
            
            # Добавляем среднее значение
            avg_wait = np.mean(wait_times)
            self.ax3.axvline(avg_wait, color='red', linestyle='--', linewidth=2, 
                            label=f'Среднее: {avg_wait:.3f}')
            
            self.ax3.set_xlabel('Время ожидания')
            self.ax3.set_ylabel('Частота')
            self.ax3.set_title('Распределение времени ожидания в очереди')
            self.ax3.legend()
            self.ax3.grid(True, alpha=0.3)
            
            # Добавляем статистику на график
            stats_text = f'n = {len(wait_times)}\n'
            stats_text += f'Мин = {min(wait_times):.3f}\n'
            stats_text += f'Макс = {max(wait_times):.3f}\n'
            stats_text += f'Ср. = {avg_wait:.3f}\n'
            stats_text += f'Ст. откл. = {np.std(wait_times):.3f}'
            
            self.ax3.text(0.98, 0.98, stats_text, transform=self.ax3.transAxes,
                         fontsize=9, verticalalignment='top', horizontalalignment='right',
                         bbox=dict(boxstyle='round', facecolor='wheat', alpha=0.5))
        else:
            self.ax3.text(0.5, 0.5, 'Нет данных об ожидании', 
                         transform=self.ax3.transAxes, ha='center', va='center')
            self.ax3.set_xlabel('Время ожидания')
            self.ax3.set_ylabel('Частота')
            self.ax3.set_title('Распределение времени ожидания в очереди')
        
        self.canvas3.draw()

def main():
    root = tk.Tk()
    app = BankSimulationGUI(root)
    root.mainloop()

if __name__ == "__main__":
    main()