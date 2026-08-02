import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { Toaster } from 'react-hot-toast';
import { ThemeProvider } from './context/ThemeContext';
import { AuthProvider, useAuth } from './context/AuthContext';
import AppLayout from './components/layout/AppLayout';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';
import Students from './pages/Students';
import Courses from './pages/Courses';
import Faculty from './pages/Faculty';
import Profile from './pages/Profile';
import EmptyState from './components/ui/EmptyState';

const ProtectedRoute = ({ children }) => {
  const { isAuthenticated } = useAuth();
  return isAuthenticated ? children : <Navigate to="/login" replace />;
};

const Placeholder = ({ title }) => (
  <div style={{ padding: '2rem' }}>
    <h2 className="text-gradient" style={{ marginBottom: '1rem' }}>{title}</h2>
    <div className="glass-card" style={{ padding: '2rem' }}>
      <EmptyState message={`${title} page is under construction`} />
    </div>
  </div>
);

function App() {
  return (
    <ThemeProvider>
      <AuthProvider>
        <Router>
          <Toaster position="top-right" toastOptions={{ className: 'glass-card' }} />
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/" element={<ProtectedRoute><AppLayout /></ProtectedRoute>}>
              <Route index element={<Dashboard />} />
              <Route path="students" element={<Students />} />
              <Route path="courses" element={<Courses />} />
              <Route path="faculty" element={<Faculty />} />
              <Route path="departments" element={<Placeholder title="Departments" />} />
              <Route path="enrollments" element={<Placeholder title="Enrollments" />} />
              <Route path="attendance" element={<Placeholder title="Attendance" />} />
              <Route path="exams" element={<Placeholder title="Exams" />} />
              <Route path="grades" element={<Placeholder title="Grades" />} />
              <Route path="timetable" element={<Placeholder title="Timetable" />} />
              <Route path="announcements" element={<Placeholder title="Announcements" />} />
              <Route path="profile" element={<Profile />} />
              <Route path="*" element={<Placeholder title="Not Found" />} />
            </Route>
          </Routes>
        </Router>
      </AuthProvider>
    </ThemeProvider>
  );
}

export default App;
