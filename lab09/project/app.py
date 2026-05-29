from collections import Counter, deque, defaultdict
import math
import random
from flask import Flask, request, jsonify, render_template

app = Flask(__name__)

def ExpRV(lambd):
    return -math.log(1 - random.random()) / lambd

def simulate_MM1_system(lambd, mu, T_total):
    current_time = 0
    state = 0 
        
    total_arrivals = 0
    served_clients = 0
    lost_clients = 0
     
    while current_time < T_total:
        dt = ExpRV(lambd)
        
        if state == 1:
            delta = ExpRV(mu)
        else:
            delta = float('inf')
        
        # Смотрим, какое событие наступит раньше
        if dt < delta:
            current_time += dt
            total_arrivals += 1
            
            if state == 0:
                state = 1
                served_clients += 1
            else:
                lost_clients += 1
        else:
            current_time += delta
            state = 0 
            
    return {
        "statistics": {
            "loss_probability": lost_clients / total_arrivals if total_arrivals > 0 else 0,
            "acceptance_probability": served_clients / total_arrivals if total_arrivals > 0 else 0
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
    T_total = float(data['T'])

    result = simulate_MM1_system(lambd, mu, T_total)

    return jsonify(result)


if __name__ == '__main__':
    app.run(debug=True)
