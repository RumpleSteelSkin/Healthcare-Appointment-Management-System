import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthProvider";

export default function PrivateRoute({ children, role }) {
    const { token, user } = useAuth();

    if (!token) return <Navigate to="/login" />;

    if (role && (!user || !user.role.includes(role))) {
        return <Navigate to="/" />;
    }

    return children;
}
