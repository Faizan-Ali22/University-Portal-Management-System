import { USE_MOCK_DATA } from './config';
import axiosInstance from './axios';

const mockCourses = [
  { id: 1, code: 'CS101', title: 'Intro to Programming', creditHours: 3, semester: 'Fall', department: 'CS', facultyName: 'Dr. Zafar', enrolledCount: 45 },
  { id: 2, code: 'CS201', title: 'Data Structures', creditHours: 4, semester: 'Spring', department: 'CS', facultyName: 'Dr. Ayesha', enrolledCount: 38 },
  { id: 3, code: 'CS301', title: 'Database Systems', creditHours: 3, semester: 'Fall', department: 'CS', facultyName: 'Dr. Rehman', enrolledCount: 42 },
  { id: 4, code: 'EE101', title: 'Circuit Analysis', creditHours: 4, semester: 'Fall', department: 'EE', facultyName: 'Dr. Tariq', enrolledCount: 50 },
  { id: 5, code: 'EE201', title: 'Signals & Systems', creditHours: 3, semester: 'Spring', department: 'EE', facultyName: 'Dr. Salman', enrolledCount: 35 },
  { id: 6, code: 'BBA101', title: 'Principles of Management', creditHours: 3, semester: 'Fall', department: 'BBA', facultyName: 'Dr. Fatima', enrolledCount: 60 },
  { id: 7, code: 'BBA201', title: 'Marketing', creditHours: 3, semester: 'Spring', department: 'BBA', facultyName: 'Dr. Hameed', enrolledCount: 55 },
  { id: 8, code: 'MATH101', title: 'Calculus I', creditHours: 3, semester: 'Fall', department: 'Math', facultyName: 'Dr. Qasim', enrolledCount: 80 },
  { id: 9, code: 'MATH201', title: 'Linear Algebra', creditHours: 3, semester: 'Spring', department: 'Math', facultyName: 'Dr. Qasim', enrolledCount: 65 },
  { id: 10, code: 'PHY101', title: 'Mechanics', creditHours: 4, semester: 'Fall', department: 'Physics', facultyName: 'Dr. Naeem', enrolledCount: 40 },
  { id: 11, code: 'PHY201', title: 'Thermodynamics', creditHours: 3, semester: 'Spring', department: 'Physics', facultyName: 'Dr. Zeeshan', enrolledCount: 30 },
  { id: 12, code: 'CS401', title: 'AI & Machine Learning', creditHours: 4, semester: 'Fall', department: 'CS', facultyName: 'Dr. Abbas', enrolledCount: 25 }
];

export const getCourses = async () => {
  if (USE_MOCK_DATA) {
    return new Promise(resolve => setTimeout(() => resolve(mockCourses), 500));
  }
  const response = await axiosInstance.get('/courses');
  return response.data;
};
