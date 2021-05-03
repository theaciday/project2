import React, { useEffect, useRef, useState } from "react";
import { Chart, registerables } from "chart.js";

Chart.register(...registerables);

const CalculateButton = () => {
    const [lifespans, setLifespans,rolling,setRolling] = useState(null);

    const chart = useRef();

    const onRolling = () => {
        fetch("/api/users/")

    };


    const onCalculate = () => {
        fetch("/api/users/getrollingret/")
           .then((response) => response.json())
           .then((data) => {
               setLifespans(data.map(item => item.Days));
           })
           .catch((error) => {
             console.error(error);
           });
    };

    useEffect(() => {
        const ctx = document.getElementById("myChart").getContext("2d");

        if (chart.current) chart.current.destroy();

        if (!lifespans) return;

        chart.current = new Chart(ctx, {
            type: "bar",
            data: {
                labels: lifespans.map((value, index) => index + 1),
                datasets: [
                    {
                        label: "Продолжительность жизни ",
                        data: lifespans,
                        backgroundColor: [
                            "rgba(255, 99, 132, 0.2)",
                            "rgba(54, 162, 235, 0.2)",
                            "rgba(255, 206, 86, 0.2)",
                            "rgba(75, 192, 192, 0.2)",
                            "rgba(153, 102, 255, 0.2)",
                            "rgba(255, 159, 64, 0.2)",
                        ],
                        borderColor: [
                            "rgba(255, 99, 132, 1)",
                            "rgba(54, 162, 235, 1)",
                            "rgba(255, 206, 86, 1)",
                            "rgba(75, 192, 192, 1)",
                            "rgba(153, 102, 255, 1)",
                            "rgba(255, 159, 64, 1)",
                        ],
                        borderWidth: 1,
                    },
                ],
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                    },
                },
            },
        });
    }, [lifespans]);

    return (
        <>
            <div>
                <button onClick={onCalculate}>Calculate</button>
            </div>
            <div style={{ maxHeight: "400px", maxWidth: "400px" }}>
                <canvas id="myChart" width="400" height="400"></canvas>
            </div>
        </>
    );
};
export default CalculateButton;