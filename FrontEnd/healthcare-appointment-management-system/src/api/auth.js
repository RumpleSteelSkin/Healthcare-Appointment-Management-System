const BASE_URL = "http://localhost:5010/api/Authentications";

export const loginRequest = async (loginData) => {
    const response = await fetch(`${BASE_URL}/Login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(loginData),
    });

    if (!response.ok) throw await response.json();
    return await response.json();
};

export const registerRequest = async (registerData) => {
    const response = await fetch(`${BASE_URL}/Register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(registerData),
    });

    if (!response.ok) throw await response.json();
    return await response.json();
};

export const getCurrentUser = async (token) => {
    const response = await fetch(`${BASE_URL}/GetCurrentUser`, {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    });

    if (!response.ok) throw await response.json();
    return await response.json();
};
