import { useState, useEffect } from "react";
import axios from "axios";

const usePostHook = (postConfig) => {
    const [data, setData] = useState(null);
    const [loading, setLoaded] = useState(false);
    const [error, setError] = useState("");
    
  
    useEffect(() => {
      (async () => {
        try {
          const response = await axios({
            method: "POST",
            url: postConfig.url,
            data: postConfig.payload,
            headers: { "Content-Type": "application/json" }
          });
  
          setData(response.data);
        } catch (error) {
          setError(error.message);
        } finally {
          setLoaded(true);
        }
      })();
    }, []);
  
    return { data, loading, error };
  };

  export default usePostHook;