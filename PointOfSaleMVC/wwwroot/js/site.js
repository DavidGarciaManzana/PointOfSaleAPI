let colors = ['#007bff', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];
let donutOptions = {
    cutoutPercentage: 85,
    legend: { position: 'bottom', padding: 5, labels: { pointStyle: 'circle', usePointStyle: true } }
};

function createBarTable(values) {
    //console.log(values.length)
    let months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    let labels = [];
    for (i = 0; i < values.length; i++) {
        labels.push(months[i])
    }
    

    const info = {
        labels: labels,
        datasets: [{
            data: values,
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
                    text: 'Total ' + new Date().getFullYear()+ ' sales'
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


function createLineTable() {

    var chLine = document.getElementById("chLine");
    var chartData = {
        labels: ["1", "2", "3", "4", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13",
            "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27",
            "28", "29", "30", "31"],
        datasets: [{
            label: 'My First Dataset',
            data: [65, 59, 80, 81, 56, 55, 40],
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
                        text: 'This month sales'
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
        let values = [];
        // console.log(data)
        let totalJanuary = null
        let totalFebruary = null
        let totalMarch = null
        let totalApril = null
        let totalMay = null
        let totalJune = null
        let totalJuly = null
        let totalAugust = null
        let totalSeptember = null
        let totalOctober = null
        let totalNovember = null
        let totalDecember = null
        data.map((item) => {
            let date = new Date(item.orderDate)
         //   console.log(date.getFullYear())
            if (item.status == "Completed" && date.getFullYear() == new Date().getFullYear()) {
                console.log(item.orderDate.slice(5, 7))
                
                if (item.orderDate.slice(5, 7) == 1) {
                    totalJanuary += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 2) {
                    totalFebruary += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 3) {
                    totalMarch += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 4) {
                    totalApril += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 5) {
                    totalMay += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 6) {
                    totalJune += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 7) {
                    totalJuly += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 8) {
                    totalAugust += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 9) {
                    totalSeptember += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 10) {
                    totalOctober += item.grandTotal
                } else if (item.orderDate.slice(5, 7) == 11) {
                    totalNovember += item.grandTotal
                }
                }else if (item.orderDate.slice(5, 7) == 12) {
                    totalDecember += item.grandTotal
                } 
        })
        if (totalJanuary) {
            values.push(totalJanuary)
        }
        if (totalFebruary) {
            values.push(totalFebruary)
        }
        if (totalMarch) {
            values.push(totalMarch)
        }
        if (totalApril) {
            values.push(totalApril)
        }
        if (totalMay) {
            values.push(totalMay)
        }
        if (totalJune) {
            values.push(totalJune)
        }
        if (totalJuly) {
            values.push(totalJuly)
        }
        if (totalAugust) {
            values.push(totalAugust)
        }
        if (totalSeptember) {
            values.push(totalSeptember)
        }
        if (totalOctober) {
            values.push(totalOctober)
        }
        if (totalNovember) {
            values.push(totalNovember)
        }
        if (totalDecember) {
            values.push(totalDecember)
        }
        
        


        createBarTable(values);
        createLineTable();
        createPieTable();
        createDoughnutTable();
    })