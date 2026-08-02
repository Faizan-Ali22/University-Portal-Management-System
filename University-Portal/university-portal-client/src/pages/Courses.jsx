import React, { useEffect, useState } from 'react';
import PageHeader from '../components/ui/PageHeader';
import DataTable from '../components/ui/DataTable';
import { getCourses } from '../api/courses';
import { LayoutGrid, List } from 'lucide-react';
import toast from 'react-hot-toast';
import './Courses.css';

const Courses = () => {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const [viewMode, setViewMode] = useState('grid'); // 'grid' or 'table'

  useEffect(() => {
    getCourses().then(data => {
      setCourses(data);
      setLoading(false);
    }).catch(() => {
      toast.error('Failed to load courses');
      setLoading(false);
    });
  }, []);

  const columns = [
    { key: 'code', label: 'Code' },
    { key: 'title', label: 'Title' },
    { key: 'department', label: 'Department' },
    { key: 'creditHours', label: 'Credits' },
    { key: 'facultyName', label: 'Instructor' },
    { key: 'enrolledCount', label: 'Enrolled' },
  ];

  const getDeptColor = (dept) => {
    const colors = {
      'CS': 'var(--color-primary)',
      'EE': 'var(--color-secondary)',
      'BBA': 'var(--color-success)',
      'Math': 'var(--color-warning)',
      'Physics': 'var(--color-error)'
    };
    return colors[dept] || 'var(--color-primary)';
  };

  return (
    <div>
      <div className="courses-header-wrapper">
        <PageHeader 
          title="Courses" 
          description="Manage university courses"
          actionText="+ Add Course"
          onAction={() => toast('Coming soon')}
        />
        <div className="view-toggle glass-card">
          <button className={`toggle-btn ${viewMode === 'grid' ? 'active' : ''}`} onClick={() => setViewMode('grid')}>
            <LayoutGrid size={18} />
          </button>
          <button className={`toggle-btn ${viewMode === 'table' ? 'active' : ''}`} onClick={() => setViewMode('table')}>
            <List size={18} />
          </button>
        </div>
      </div>

      {loading ? (
        <div>Loading...</div>
      ) : viewMode === 'table' ? (
        <DataTable columns={columns} data={courses} loading={loading} />
      ) : (
        <div className="courses-grid">
          {courses.map(course => (
            <div key={course.id} className="course-card glass-card" style={{ borderTop: `4px solid ${getDeptColor(course.department)}` }}>
              <div className="course-card-header">
                <span className="course-code" style={{ background: `${getDeptColor(course.department)}22`, color: getDeptColor(course.department) }}>
                  {course.code}
                </span>
                <span className="course-credits">{course.creditHours} Credits</span>
              </div>
              <h3 className="course-title">{course.title}</h3>
              <div className="course-details">
                <p><span>Instructor:</span> {course.facultyName}</p>
                <p><span>Semester:</span> {course.semester}</p>
                <p><span>Enrolled:</span> {course.enrolledCount} students</p>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Courses;
