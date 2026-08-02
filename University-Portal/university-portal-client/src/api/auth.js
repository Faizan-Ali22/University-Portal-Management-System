import { USE_MOCK_DATA } from './config';
import axiosInstance from './axios';

export const login = async (email, password) => {
  if (USE_MOCK_DATA) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        if (email === 'admin@university.edu' && password === 'Admin123!') {
          resolve({
            token: 'mock-jwt-token',
            user: {
              id: 1,
              name: 'Admin User',
              email: 'admin@university.edu',
              role: 'admin',
              avatar: 'https://ui-avatars.com/api/?name=Admin+User&background=random'
            }
          });
        } else {
          reject(new Error('Invalid email or password'));
        }
      }, 1000);
    });
  }
  const response = await axiosInstance.post('/auth/login', { email, password });
  return response.data;
};
