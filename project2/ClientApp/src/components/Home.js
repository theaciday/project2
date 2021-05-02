import React, { useEffect, useState } from "react";
import { Chart, registerables } from "chart.js";
import CalculateButton from "./CalculateButton";

export const Home = () => {
    const [Users, setUsers] = useState([]);
    const [DateRegistration, setDateRegistration] = useState("");
    const [DateLastVisit, setDateLastVisit] = useState("");

    const loadUsers = () => {
        fetch("/api/users/")
            .then((response) => response.json())
            .then((data) => {
                setUsers(data);
            })
            .catch((error) => {
                console.error(error);
            });
    };

    useEffect(() => {
        loadUsers();
    }, []);

    return (
         <>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Registration date</th>
                    <th>Last visit date</th>
                    <th />
                </tr>
            </thead>
            <tbody>
                {Users.map((User) => (
                    <tr key={User.Id}>
                        <td>{User.Id}</td>
                        <td>{User.DateRegistration}</td>
                        <td>{User.DateLastVisit}</td>
                        <td />
                    </tr>
                ))}
                <tr>
                    <td />
                    <td>
                        <input
                            type="date"
                            placeholder="Registration date"
                            value={DateRegistration}
                            onChange={(event) => {
                                setDateRegistration(event.target.value);
                            }}
                        />
                    </td>
                    <td>
                        <input
                            type="date"
                            placeholder="Last visit date"
                            value={DateLastVisit}
                            onChange={(event) => {
                                setDateLastVisit(event.target.value);
                            }}
                        />
                    </td>
                    <td>
                        <button
                            onClick={() => {
                                fetch("/api/users/", {
                                    method: "post",
                                    body: JSON.stringify({ DateRegistration, DateLastVisit }),
                                    headers: { "Content-Type": "application/json" },
                                })
                                    .then((response) => response.json())
                                    .then(() => {
                                        setDateRegistration("");
                                        setDateLastVisit("");
                                        loadUsers();
                                    })
                                    .catch((error) => {
                                        console.error(error);
                                    });
                            }}
                            disabled={!DateRegistration || !DateLastVisit}
                        >
                            Save
            </button>
                    </td>
                </tr>
            </tbody>
            </table>
            <CalculateButton />
        </>

    );
};