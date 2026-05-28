from collections import Counter, deque, defaultdict
import math
import random
from flask import Flask, request, jsonify, render_template

app = Flask(__name__)

def ExpRV(lambd):
    return -math.log(1 - random.random()) / lambd

def simulate_MM1_queue(lambd, mu, T_total):
    current_time = 0
    state = 0
        
    served_clients = 0
    lost_clients = 0
    
    print(ExpRV(lambd))
    print(ExpRV(mu))
     
    while current_time < T_total:
        dt = ExpRV(lambd)
        
        if state == 1:
            delta = ExpRV(mu)
        
        else:
            delta = float('inf')
        
        if dt < delta:
            served_clients += 1
            state = 1   
            current_time += dt         
        else:
            lost_clients+=1
            state = 0
            current_time += delta
    
    return {
        "statistics":
        {
        "served": served_clients/(served_clients + lost_clients),
        "lost": lost_clients/(served_clients + lost_clients),
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

    result = simulate_MM1_queue(lambd, mu, T_total)

    return jsonify(result)


if __name__ == '__main__':
    app.run(debug=True)
