import React from 'react';
import { useCountdown } from '../hooks/useCountdown';
import DateTimeDisplay from './DateTimeDisplay';
import useAuth from '../hooks/useAuth';
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";


const ShowCounter = ({ minutes, seconds }) => {
    return (
        <div className="show-counter">
            <a
                className="countdown-link"
            >
                <DateTimeDisplay value={minutes} type={'Mins'} isDanger={false} />
                <p>:</p>
                <DateTimeDisplay value={seconds} type={'Seconds'} isDanger={false} />
            </a>
        </div>
    );
};


const CountdownTimer = () => {
    const navigate = useNavigate();
    const { auth } = useAuth();
    const { exp } = jwtDecode(auth?.accessToken);
    const [minutes, seconds] = useCountdown(exp * 1000);
    if (minutes+seconds <= 0) {
        navigate("/");
    };
    return (
        <ShowCounter
            minutes={minutes}
            seconds={seconds}
        />
    );
};

export default CountdownTimer;