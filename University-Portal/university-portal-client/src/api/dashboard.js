import { USE_MOCK_DATA } from './config';
import axiosInstance from './axios';

export const getDashboardStats = async () => {
  if (USE_MOCK_DATA) {
    return new Promise(resolve => setTimeout(() => resolve({
      totalStudents: 156,
      totalCourses: 42,
      totalFaculty: 28,
      totalDepartments: 5,
      activeEnrollments: 312
    }), 500));
  }
  const response = await axiosInstance.get('/dashboard/stats');
  return response.data;
};
