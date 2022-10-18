let colors = ['#007bff', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];
let donutOptions = {
    cutoutPercentage: 85,
    legend: { position: 'bottom', padding: 5, labels: { pointStyle: 'circle', usePointStyle: true } }
};

function createBarTable(yearValues) {
    let months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];
   
    

    const info = {
        labels: months.slice(0, months.indexOf(new Date().toLocaleString('en-US', { month: 'long' }))+1),
        datasets: [{
            data: yearValues,
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)'
            ],
            borderColor: [
                'rgb(255, 99, 132)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
                'rgb(153, 102, 255)',
                'rgb(255, 99, 132)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
                'rgb(153, 102, 255)'
            ],
            borderWidth: 2
        }]
    };
    const config = {
        type: 'bar',
        data: info,
        options: {
           
            plugins: {
                legend: {
                    display: false
                },
                title: {
                    display: true,
                    text: 'Total ' + new Date().getFullYear() + ' sales'
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        },
    };
    /* bar chart */
    var chBar = document.getElementById("chBar");
    if (chBar) {
        new Chart(chBar,
            config
        )
    }
    
}


function createLineTable(monthValues) {

    for (let index = 0; index < monthValues.length; index++) {
        if (monthValues[index] === 0) {
            monthValues[index] = NaN;
            
        }
    }
    let days = ["1", "2", "3", "4", "5", "6",
        "7", "8", "9", "10", "11", "12",
        "13", "14", "15", "16", "17", "18",
        "19", "20", "21", "22", "23", "24",
        "25", "26", "27", "28", "29", "30",
        "31"]

    var chLine = document.getElementById("chLine");
    var chartData = {
        labels: days.slice(0, new Date().getDate()),
        datasets: [{
            data: monthValues,
            fill: false,
            borderColor: 'rgb(255, 99, 132)',
            tension: 0.1
        }]
    };
    if (chLine) {
        new Chart(chLine, {
            type: 'line',
            data: chartData,
            options: {
                plugins: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: true,
                        text: new Date().toLocaleString('en-US', { month: 'long' }) + ' sales'
                    }
                },
                scales: {
                    y: {
                        stacked: true
                    }
                },
                legend: {
                    display: false
                },
                responsive: true
            }
        });
    }
}


function createPieTable() {

    var chDonutData1 = {
        labels: [
            'Red',
            'Blue',
            'Yellow'
        ],
        datasets: [{
            label: 'My First Dataset',
            data: [300, 50, 100],
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)'
            ],
            hoverOffset: 4
        }]
    };
    var chDonut1 = document.getElementById("chDonut1");
    if (chDonut1) {
        new Chart(chDonut1, {
            type: 'pie',
            data: chDonutData1,
            options: donutOptions

        });
    }

}

function createDoughnutTable() {
    var chDonutData2 = {
        labels: [
            'Red',
            'Blue',
            'Yellow'
        ],
        datasets: [{
            label: 'My First Dataset',
            data: [300, 50, 100],
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)'
            ],
            hoverOffset: 4
        }]
    };
    var chDonut2 = document.getElementById("chDonut2");
    if (chDonut2) {
        new Chart(chDonut2, {
            type: 'doughnut',
            data: chDonutData2,
            options: donutOptions
        });
    }

}



var urlorders = "https://localhost:7037/api/order";
fetch(urlorders, { method: "GET" })
    .then(resp => resp.json())
    .then(data => {
        let monthValues = [0,0,0,0,0,0,0,0,0,0,0,0];

        let dayValues = [0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0];
        console.log(data)
        data.map((item) => {
            let date = new Date(item.orderDate)

            if (item.status == "Completed" && date.getFullYear() == new Date().getFullYear()) {
                monthValues[date.getMonth()] += item.grandTotal
            }
            
            if (item.status == "Completed" && date.getFullYear() == new Date().getFullYear() && date.getMonth() == new Date().getMonth()) {
                dayValues[date.getDate()-1] += item.grandTotal
            }
        })
        
        createBarTable(monthValues);
        createLineTable(dayValues);

        createPieTable();
        createDoughnutTable();
    })