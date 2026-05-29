async function runSimulation() {

    const lambda = document.getElementById('lambda').value;
    const mu = document.getElementById('mu').value;
    const T = document.getElementById('T').value;

    const response = await fetch('/simulate', {

        method: 'POST',

        headers: {
            'Content-Type': 'application/json'
        },

        body: JSON.stringify({
            lambda,
            mu,
            T
        })
    });

    const data = await response.json();

    showStatistics(data.statistics);
}



function showStatistics(stats) {

    document.getElementById('served').innerHTML =
        `Вероятность обслужить заявку: ${stats.acceptance_probability.toFixed(3)}`;

    document.getElementById('lost').innerHTML =
        `Вероятность потерять заявку: ${stats.loss_probability.toFixed(3)}`;

}