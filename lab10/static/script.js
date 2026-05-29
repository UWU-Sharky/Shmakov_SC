let charts = {
    ops: null,
    queue: null,
    wait: null
};

const btnStart = document.getElementById('btn-start');
const statusLabel = document.getElementById('sim-status');

function initCharts(maxOps, maxQueue) {
    // График занятых операторов
    if (charts.ops) charts.ops.destroy();
    const ctxOps = document.getElementById('chart-ops').getContext('2d');
    charts.ops = new Chart(ctxOps, {
        type: 'bar',
        data: {
            labels: Array.from({length: maxOps + 1}, (_, i) => `${i}`),
            datasets: [{
                label: 'Доля времени',
                data: [],
                backgroundColor: 'rgba(59, 130, 246, 0.65)',
                borderColor: 'rgb(59, 130, 246)',
                borderWidth: 1.5,
                borderRadius: 6
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { legend: { display: false } },
            scales: { 
                y: { beginAtZero: true, max: 1, title: { display: true, text: 'Вероятность' } }, 
                x: { title: { display: true, text: 'Число занятых приборов' } } 
            }
        }
    });

    // График клиентов в очереди
    if (charts.queue) charts.queue.destroy();
    const ctxQueue = document.getElementById('chart-queue').getContext('2d');
    charts.queue = new Chart(ctxQueue, {
        type: 'bar',
        data: {
            labels: Array.from({length: maxQueue + 1}, (_, i) => `${i}`),
            datasets: [{
                label: 'Доля времени',
                data: [],
                backgroundColor: 'rgba(16, 185, 129, 0.65)',
                borderColor: 'rgb(16, 185, 129)',
                borderWidth: 1.5,
                borderRadius: 6
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { legend: { display: false } },
            scales: { 
                y: { beginAtZero: true, max: 1, title: { display: true, text: 'Вероятность' } }, 
                x: { title: { display: true, text: 'Клиентов в очереди' } } 
            }
        }
    });

    // График распределения гистограмма частот времени пребывания в очереди
    if (charts.wait) charts.wait.destroy();
    const ctxWait = document.getElementById('chart-wait').getContext('2d');
    charts.wait = new Chart(ctxWait, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Количество клиентов',
                data: [],
                backgroundColor: 'rgba(245, 158, 11, 0.65)',
                borderColor: 'rgb(245, 158, 11)',
                borderWidth: 1.5,
                borderRadius: 6
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { legend: { display: false } },
            scales: { 
                y: { beginAtZero: true, title: { display: true, text: 'Количество клиентов' } }, 
                x: { title: { display: true, text: 'Интервалы времени ожидания' } } 
            }
        }
    });
}

// Обработчик события запуска симуляции
btnStart.addEventListener('click', async () => {
    const ops = parseInt(document.getElementById('param-ops').value);
    const queue = parseInt(document.getElementById('param-queue').value);
    const arr = parseFloat(document.getElementById('param-arr').value);
    const srv = parseFloat(document.getElementById('param-srv').value);
    const pat = parseFloat(document.getElementById('param-pat').value);
    const timeLimit = parseFloat(document.getElementById('param-time').value);

    btnStart.disabled = true;
    statusLabel.innerHTML = `<span class="w-2 h-2 rounded-full bg-blue-500 animate-pulse"></span> Вычисление...`;

    initCharts(ops, queue);

    try {
        const res = await fetch('/api/simulate', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ ops, queue, arr, srv, pat, timeLimit })
        });
        const data = await res.json();

        document.getElementById('metric-p-serve').innerText = (data.p_serve * 100).toFixed(1) + '%';
        document.getElementById('metric-p-drop').innerText = (data.p_drop * 100).toFixed(1) + '%';
        document.getElementById('metric-avg-q').innerText = data.avg_q_len.toFixed(2);
        document.getElementById('metric-avg-w').innerText = data.avg_wait.toFixed(2);

        document.getElementById('stat_total').innerText = data.stats.total;
        document.getElementById('stat_served').innerText = data.stats.served;
        document.getElementById('stat_abandoned').innerText = data.stats.abandoned;
        document.getElementById('stat_rejected').innerText = data.stats.rejected;

        charts.ops.data.datasets[0].data = data.charts.ops_values;
        charts.ops.update();

        charts.queue.data.datasets[0].data = data.charts.queue_values;
        charts.queue.update();

        const waitTimes = data.charts.wait_times;
        if (waitTimes.length > 0) {
            const numBins = 10;
            const maxWait = Math.max(...waitTimes) || 1;
            const binWidth = maxWait / numBins;
            const bins = new Array(numBins).fill(0);
            const labels = [];

            for (let i = 0; i < numBins; i++) {
                labels.push(`${(i * binWidth).toFixed(1)}-${((i + 1) * binWidth).toFixed(1)}`);
            }

            waitTimes.forEach(w => {
                let binIdx = Math.floor(w / binWidth);
                if (binIdx >= numBins) binIdx = numBins - 1;
                if (binIdx < 0) binIdx = 0;
                bins[binIdx]++;
            });

            charts.wait.data.labels = labels;
            charts.wait.data.datasets[0].data = bins;
            charts.wait.update();
        }

        statusLabel.innerHTML = `<span class="w-2 h-2 rounded-full bg-green-500"></span> Расчет завершен`;

    } catch (e) {
        console.error("Ошибка во время выполнения моделирования:", e);
        statusLabel.innerHTML = `<span class="w-2 h-2 rounded-full bg-red-500"></span> Ошибка расчета`;
    } finally {
        btnStart.disabled = false;
    }
});