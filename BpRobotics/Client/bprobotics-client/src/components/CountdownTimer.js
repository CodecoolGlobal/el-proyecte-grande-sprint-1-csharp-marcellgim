import React from 'react';
import { useCountdown } from '../hooks/useCountdown';
import DateTimeDisplay from './DateTimeDisplay';
import useAuth from '../hooks/useAuth';
import jwtDecode from "jwt-decode";


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
    const { auth } = useAuth();
    const { exp } = jwtDecode(auth?.accessToken);
    const [minutes, seconds] = useCountdown(exp * 1000);

    return (
        <ShowCounter
            minutes={minutes}
            seconds={seconds}
        />
    );
};

export default CountdownTimer;