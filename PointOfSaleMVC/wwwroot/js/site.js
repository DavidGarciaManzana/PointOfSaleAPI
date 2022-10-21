let mantain = false;
// Create a condition that targets viewports at least 768px wide
const mediaQuery = window.matchMedia('(min-width: 768px)')


function handleTabletChange(e) {
    // Check if the media query is true
    if (e.matches) {
        // Then log the following message to the console
        console.log('Media Query Matched!')
        mantain = true
        console.log(mantain)
    } else {
        mantain = false
        console.log('kakakkaka', mantain)
    }
}


// Register event listener
mediaQuery.addListener(handleTabletChange)

// Initial check
handleTabletChange(mediaQuery)

let colors = ['#007bff', '#28a745', '#333333', '#c3e6cb', '#dc3545', '#6c757d'];


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
            },
            
            maintainAspectRatio: mantain
           
        },
    };
    /* bar chart */
    var chBar = document.getElementById("chBar");
    if (chBar) {
        let barchart = new Chart(chBar,
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
                responsive: true,
                maintainAspectRatio: mantain
            }
        });
    }
}


function createPieTable(data) {
    let countries = []
    let sales  = []

    data.map((item) => {
        countries.push(item.country)
        sales.push(item.sales)
    })

    var chDonutData1 = {
        labels: countries,
        datasets: [{
            data: sales,
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)'
            ],
            hoverOffset: 4
        }]
    };
    let donutOptions = {
        cutoutPercentage: 85,
        legend: {
            position: 'bottom', padding: 5, labels: { pointStyle: 'circle', usePointStyle: true }
        },
        plugins: {
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: new Date().getFullYear() + ' sales by Country'
            }
        },
        maintainAspectRatio: mantain
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

function createDoughnutTable(data, bestSalesCountry) {
    let cities = []
    let sales = []
    if (bestSalesCountry.country == "México") {
        data.map((item) => {
            if (item.city == "Zihuatanejo" || item.city == "Guadalajara" || item.city == "CDMX") {
                cities.push(item.city)
                sales.push(item.sales)
            }
        })
    }
    if (bestSalesCountry.country == "Canada") {
        data.map((item) => {
            if (item.city == "Montreal" || item.city == "Toronto" || item.city == "Vancouver") {
                cities.push(item.city)
                sales.push(item.sales)
            }
        })
    }
    if (bestSalesCountry.country == "USA") {
        data.map((item) => {
            if (item.city == "Boston" || item.city == "Chicago" || item.city == "New York") {
                cities.push(item.city)
                sales.push(item.sales)
            }
        })
    }

    


    var chDonutData2 = {
        labels: cities,
        datasets: [{
            label: 'My First Dataset',
            data: sales,
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)'
            ],
            hoverOffset: 4
        }]
    };

    let donutOptions = {
        cutoutPercentage: 85,
        legend: {
            position: 'bottom', padding: 5, labels: { pointStyle: 'circle', usePointStyle: true }
        },
        plugins: {
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: new Date().getFullYear() + ' sales by cities in the country with bigger sales'
            }
        },
        maintainAspectRatio: mantain
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



var urlOrders = "https://localhost:7037/api/order";
fetch(urlOrders, { method: "GET" })
    .then(resp => resp.json())
    .then(data => {
        let monthValues = [0,0,0,0,0,0,0,0,0,0,0,0];

        let dayValues = [0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0];
     
        data.map((item) => {
            let date = new Date(item.orderDate)

            if (item.status == "Completed" && date.getFullYear() == new Date().getFullYear() && date <= new Date()) {
                monthValues[date.getMonth()] += item.grandTotal
            }

            if (item.status == "Completed" && date.getFullYear() == new Date().getFullYear() && date.getMonth() == new Date().getMonth() && date <= new Date() ) {
                dayValues[date.getDate()-1] += item.grandTotal
            }
        })
        
        createBarTable(monthValues);
        createLineTable(dayValues);

        
        
    })

var urlGetCountrySales = "https://localhost:7037/api/GetCountrySales";
fetch(urlGetCountrySales, { method: "GET" })
    .then(resp => resp.json())
    .then(data => {
 
        createPieTable(data);
        let bestSalesCountry = data.sort((a, b) => b.sales - a.sales)[0]
        
        var urlGetCountrySales = "https://localhost:7037/api/GetCitySales";
        fetch(urlGetCountrySales, { method: "GET" })
            .then(resp => resp.json())
            .then(data => {
                
                createDoughnutTable(data, bestSalesCountry);

            })

    })