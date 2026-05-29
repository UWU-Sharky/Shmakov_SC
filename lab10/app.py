from flask import Flask, render_template, request, jsonify
from Bank_app import BankSystem 

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/api/simulate', methods=['POST'])
def simulate():
    data = request.json
    max_time = float(data.get('timeLimit', 1000.0))
    num_ops = int(data['ops'])
    max_q = int(data['queue'])
    
    model = BankSystem(
        num_operators=num_ops,
        max_queue=max_q,
        arrival_rate=float(data['arr']),
        service_rate=float(data['srv']),
        patience_rate=float(data['pat'])
    )
    
    model.run(max_time)
    
    served = model.stats['completed']
    abandoned = model.stats['abandoned']
    rejected = model.stats['rejected_queue_full']
    total_arrivals = served + abandoned + rejected
    
    # Эмпирические вероятности обслуживания и потери заявки
    p_serve = served / total_arrivals if total_arrivals > 0 else 0.0
    p_drop = (abandoned + rejected) / total_arrivals if total_arrivals > 0 else 0.0
    
    # Расчет средней длины очереди
    avg_q_len = sum(q * t for q, t in enumerate(model.time_in_queue)) / max_time
    
    # Расчет среднего времени ожидания в очереди
    wait_times = model.stats['wait_times']
    avg_wait = sum(wait_times) / len(wait_times) if wait_times else 0.0
    
    # Подготовка эмпирических распределений для графиков
    ops_fractions = [t / max_time for t in model.time_in_ops]
    q_fractions = [t / max_time for t in model.time_in_queue]
    
    return jsonify({
        'p_serve': p_serve,
        'p_drop': p_drop,
        'avg_q_len': avg_q_len,
        'avg_wait': avg_wait,
        'stats': {
            'total': total_arrivals,
            'served': served,
            'abandoned': abandoned,
            'rejected': rejected
        },
        'charts': {
            'ops_values': ops_fractions,
            'queue_values': q_fractions,
            'wait_times': wait_times
        }
    })

if __name__ == '__main__':
    app.run(debug=True)