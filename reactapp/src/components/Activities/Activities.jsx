import React, { useContext } from "react";
import useFetchData from "../../hooks/useFetchData";
import { UserContext } from "../../hooks/UserContext";

const Activities = () => {
    const {user} = useContext(UserContext);

    // Set up fetch request
    const fetchRequest =  {
        url: `/activity/user-activities/${user.id}`, 
        method: "GET",
        headers: {
            Authorization: `Bearer ${localStorage["auth-token"]}`,
        },
    };

    const {data, loading, error} = useFetchData(fetchRequest);

    console.log(data)

    return(
        <>stuff</>
    );
};

export default Activities;