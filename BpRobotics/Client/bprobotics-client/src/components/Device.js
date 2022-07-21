import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChevronDown } from "@fortawesome/free-solid-svg-icons";
import Services from "./Services";
import React, { useState } from "react";

function Device({ device, columns, children }) {
    const [showServices, setShowServices] = useState(false);

    const toggleServices = () => setShowServices(!showServices);

    return (
        <React.Fragment key={device.id}>
            <tr>
                {columns.map((column, index) => (
                    <td key={index}>{column.render(device[column.field])}</td>
                ))}
                <td><FontAwesomeIcon className="clickable" onClick={toggleServices} icon={faChevronDown} /></td>
            </tr>
            {showServices && 
                <>
                    <tr><td>{children}</td></tr>
                    <tr><td><Services services={device.services} deviceId={device.id} /></td></tr>
                </>
            }
        </React.Fragment>
    );
}

export default Device;