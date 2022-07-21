import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChevronDown } from "@fortawesome/free-solid-svg-icons";
import Services from "./Services";
import { useState } from "react";

function Device({ device, columns }) {
    const [showServices, setShowServices] = useState(false);

    const toggleServices = () => setShowServices(!showServices);

    return (
        <>
            <tr key={device.id}>
                {columns.map((column, index) => (
                    <td key={index}>{column.render(device[column.field])}</td>
                ))}
                <td><FontAwesomeIcon className="clickable" onClick={toggleServices} icon={faChevronDown} /></td>
            </tr>
            {showServices && <tr><td><Services services={device.services} /></td></tr>}
        </>
    );
}

export default Device;