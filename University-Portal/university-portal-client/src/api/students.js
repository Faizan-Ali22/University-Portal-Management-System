import { USE_MOCK_DATA } from './config';
import axiosInstance from './axios';

const mockStudents = [
  { id: 1, name: 'Ahmed Khan', email: 'ahmed@university.edu', department: 'CS', gpa: 3.8, enrollmentDate: '2022-09-01' },
  { id: 2, name: 'Sara Ali', email: 'sara@university.edu', department: 'EE', gpa: 3.5, enrollmentDate: '2021-09-01' },
  { id: 3, name: 'Hassan Malik', email: 'hassan@university.edu', department: 'BBA', gpa: 2.8, enrollmentDate: '2023-01-15' },
  { id: 4, name: 'Ayesha Iqbal', email: 'ayesha@university.edu', department: 'Math', gpa: 3.9, enrollmentDate: '2020-09-01' },
  { id: 5, name: 'Omar Farooq', email: 'omar@university.edu', department: 'Physics', gpa: 2.4, enrollmentDate: '2022-09-01' },
  { id: 6, name: 'Fatima Zafar', email: 'fatima@university.edu', department: 'CS', gpa: 3.2, enrollmentDate: '2023-09-01' },
  { id: 7, name: 'Ali Raza', email: 'ali@university.edu', department: 'EE', gpa: 2.9, enrollmentDate: '2021-09-01' },
  { id: 8, name: 'Zainab Noor', email: 'zainab@university.edu', department: 'CS', gpa: 4.0, enrollmentDate: '2022-09-01' },
  { id: 9, name: 'Bilal Ahmed', email: 'bilal@university.edu', department: 'BBA', gpa: 3.1, enrollmentDate: '2023-01-15' },
  { id: 10, name: 'Hina Tariq', email: 'hina@university.edu', department: 'Math', gpa: 3.6, enrollmentDate: '2021-09-01' },
  { id: 11, name: 'Saad Mahmood', email: 'saad@university.edu', department: 'CS', gpa: 2.7, enrollmentDate: '2022-09-01' },
  { id: 12, name: 'Kiran Shah', email: 'kiran@university.edu', department: 'Physics', gpa: 3.4, enrollmentDate: '2020-09-01' },
  { id: 13, name: 'Usman Jamil', email: 'usman@university.edu', department: 'EE', gpa: 3.7, enrollmentDate: '2023-09-01' },
  { id: 14, name: 'Sana Qureshi', email: 'sana@university.edu', department: 'BBA', gpa: 2.3, enrollmentDate: '2021-09-01' },
  { id: 15, name: 'Fahad Riaz', email: 'fahad@university.edu', department: 'CS', gpa: 3.3, enrollmentDate: '2022-09-01' }
];

export const getStudents = async () => {
  if (USE_MOCK_DATA) {
    return new Promise(resolve => setTimeout(() => resolve(mockStudents), 500));
  }
  const response = await axiosInstance.get('/students');
  return response.data;
};
