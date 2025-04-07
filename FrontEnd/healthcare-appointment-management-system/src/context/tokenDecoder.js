export const decodeJwt = (token) => {
    try {
        const payload = token.split('.')[1];
        const decodedPayload = atob(payload);
        return JSON.parse(decodedPayload);
    } catch (error) {
        console.error("Token decode edilemedi:", error);
        return null;
    }
};

export const hasRole = (decodedToken, requiredRole) => {
    if (!decodedToken) return false;

    const roleClaim =
        "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    const userRole = decodedToken[roleClaim];

    if (Array.isArray(userRole)) {
        return userRole.includes(requiredRole);
    }

    return userRole === requiredRole;
};
