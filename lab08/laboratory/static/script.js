document.getElementById('runBtn').addEventListener('click', async () => {
    const params = {
        lambda: parseFloat(document.getElementById('lambda').value),
        timeT: parseFloat(document.getElementById('timeT').value),
        numExp: parseInt(document.getElementById('numExp').value),
        T_total: parseFloat(document.getElementById('T_total').value) // Новый параметр
    };

    const response = await fetch('/simulate', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(params)
    });
    
    const data = await response.json();
    
    document.getElementById('mean').innerText = data.mean.toFixed(3);
    document.getElementById('variance').innerText = data.variance.toFixed(3);
    
    updateChart(data.labels, data.values);
});

let myChart = null; // Глобальная переменная для хранения экземпляра графика

function updateChart(labels, values) {
    const ctx = document.getElementById('distributionChart').getContext('2d');
    
    if (myChart) {
        myChart.destroy(); // Уничтожаем старый график перед созданием нового
    }

    myChart = new Chart(ctx, {
        type: 'bar', // Столбчатая диаграмма лучше всего подходит для дискретных величин
        data: {
            labels: labels,
            datasets: [{
                label: 'Эмпирическая вероятность P(X=k)',
                data: values,
                backgroundColor: 'rgba(26, 115, 232, 0.6)',
                borderColor: '#1a73e8',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: { beginAtZero: true, title: { display: true, text: 'Вероятность' } },
                x: { title: { display: true, text: 'Число запросов за интервал T' } }
            },
            plugins: {
                legend: { display: true }
            }
        }
    });
}