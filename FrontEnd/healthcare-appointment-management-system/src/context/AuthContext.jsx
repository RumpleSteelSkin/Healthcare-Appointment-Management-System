import { createContext, useState, useEffect } from "react";
import {Navigate} from "react-router-dom";

const AuthContext = createContext(undefined);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [token, setToken] = useState(localStorage.getItem("token") || null);

    useEffect(() => {
        if (token) {
            setUser({ token });
        }
    }, [token]);

    const loginUser = (token) => {
        setToken(token);
        localStorage.setItem("token", token);
    };

    const logoutUser = () => {
        setToken(null);
        setUser(null);
        localStorage.removeItem("token");
        return <Navigate to="/login" replace />;
    };

    return (
        <AuthContext.Provider value={{ user, token, loginUser, logoutUser }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContext;