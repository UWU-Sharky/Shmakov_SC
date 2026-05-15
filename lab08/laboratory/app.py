import math
import random
from flask import Flask, request, jsonify, render_template

app = Flask(__name__)

# --- ЛОГИКА МОДЕЛИРОВАНИЯ ---

def simulate_poisson_process(lambd, T_total):
    events = []
    current_time = 0
    
    while current_time < T_total:
        
        tau = -math.log(1 - random.random()) / lambd
        current_time += tau
        
        if current_time < T_total:
            events.append(current_time)
            
    return events


def get_statistics(events_list, T_totals, T, N):
    frequencies = {}  
    raw_counts = []   
    for _ in range(N):
        a = random.uniform(0, T_totals - T)
        
        count = len([e for e in events_list if a <= e < a + T])
        
        frequencies[count] = frequencies.get(count, 0) + 1
        
        raw_counts.append(count)
            
    empirical_distribution = {i: freq / N for i, freq in sorted(frequencies.items())}
    
    mean = sum(raw_counts) / N
    variance = sum((x - mean)**2 for x in raw_counts) / N
    
    return empirical_distribution, mean, variance

@app.route('/simulate', methods=['POST'])
def handle_simulation():
    data = request.json
    lambd = float(data.get('lambda'))
    T = float(data.get('timeT'))
    T_totals = float(data.get('T_total'))
    N = int(data.get('numExp'))
    events = simulate_poisson_process(lambd, T_totals)
    distribution, mean, variance = get_statistics(events, T_totals, T, N)

    return jsonify({
        "labels": list(distribution.keys()), # [0, 1, 2, 3...]
        "values": list(distribution.values()), # [0.05, 0.12, ...]
        "mean": mean,
        "variance": variance
    })

@app.route('/')
def index():
    return render_template('index.html')

if __name__ == '__main__':
    app.run(debug=True)