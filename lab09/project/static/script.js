async function runSimulation() {

    const lambda = document.getElementById('lambda').value;
    const mu = document.getElementById('mu').value;
    const N = document.getElementById('N').value;
    const T = document.getElementById('T').value;

    const response = await fetch('/simulate', {

        method: 'POST',

        headers: {
            'Content-Type': 'application/json'
        },

        body: JSON.stringify({
            lambda,
            mu,
            N,
            T
        })
    });

    const data = await response.json();

    buildStateChart(data.states);

    buildWaitChart(data.waiting_times);

    showStatistics(data.statistics);
}


let statesChart = null;
let waitChart = null;


function showStatistics(stats) {

    document.getElementById('avg_wait').innerHTML =
        `Среднее ожидание: ${stats.avg_wait.toFixed(3)}`;

    document.getElementById('avg_clients').innerHTML =
        `Среднее число клиентов: ${stats.avg_clients.toFixed(3)}`;

    document.getElementById('avg_queue').innerHTML =
        `Средняя длина очереди: ${stats.avg_queue.toFixed(3)}`;

    document.getElementById('rho').innerHTML =
        `Коэффициент загрузки: ${stats.rho.toFixed(3)}`;
}

function buildStateChart(states) {

    const labels = Object.keys(states);

    const values = Object.values(states);

    const ctx = document.getElementById('statesChart');

    if (statesChart)
        statesChart.destroy();

    statesChart = new Chart(ctx, {

        type: 'bar',

        data: {
            labels: labels,

            datasets: [{
                label: 'Распределение кол-ва клиентов по времени пребывания в системе',

                data: values
            }]
        }
    });
}


function buildWaitChart(waitingTimes) {

    const freq = {};

    waitingTimes.forEach(t => {

        const rounded = Math.round(t);

        if (!freq[rounded])
            freq[rounded] = 0;

        freq[rounded]++;
    });

    const labels = Object.keys(freq);

    const values = Object.values(freq);

    const ctx = document.getElementById('waitChart');

    if (waitChart)
        waitChart.destroy();

    waitChart = new Chart(ctx, {

        type: 'line',

        data: {
            labels: labels,

            datasets: [{
                label: 'Время ожидания клиентов в очереди',

                data: values
            }]
        }
    });
}