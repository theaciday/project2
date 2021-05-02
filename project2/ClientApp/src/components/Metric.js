import React, { useEffect, useState } from "react";

export const Metric = () => {
    const [Users, setUsers] = useState([]);
    const [RollingUser, setRollingUser] = useState([]);
    const [LiveSpan, setLiveSpan] = useState([]);

    const RolUser = () => {
        fetch("api/getrollingret")
            .then((response) => response.json())
            .then((data) => {
                setUsers(data);
            })
            .catch((error) => {
                console.error(error);
            });
    };


    return (
        <td></td>
    );
};
<canvas id="myDiagram" width="400" height="400"></canvas>
export const 