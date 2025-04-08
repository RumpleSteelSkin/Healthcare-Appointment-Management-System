import { create } from 'zustand';
import { jwtDecode } from 'jwt-decode';

interface JWTPayload {
  role: string | string[];
  exp: number;
  [key: string]: any;
}

interface AuthState {
  token: string | null;
  roles: string[];
  isAuthenticated: boolean;
  setToken: (token: string) => void;
  logout: () => void;
  hasRole: (role: string) => boolean;
}
export const useAuthStore = create<AuthState>((set, get) => ({
  token: localStorage.getItem('token'),
  roles: [],
  isAuthenticated: !!localStorage.getItem('token'),

  setToken: (token: string) => {
    localStorage.setItem('token', token);
    const decoded = jwtDecode<JWTPayload>(token);
    const roleClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
    let roles: string[];
    const rawRole = decoded[roleClaim];
    if (typeof rawRole === 'string') {
      roles = [rawRole];
    } else if (Array.isArray(rawRole)) {
      roles = rawRole;
    } else {
      roles = [];
    }
    set({ token, roles, isAuthenticated: true });
  },

  logout: () => {
    localStorage.removeItem('token');
    set({ token: null, roles: [], isAuthenticated: false });
  },

  hasRole: (role: string) => {
    const { roles } = get();
    return roles.map(r => r.toLowerCase()).includes(role.toLowerCase());
  },
}));
