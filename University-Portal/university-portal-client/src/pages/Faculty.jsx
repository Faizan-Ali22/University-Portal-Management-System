import React, { useState } from 'react';
import PageHeader from '../components/ui/PageHeader';
import Modal from '../components/ui/Modal';
import { Mail, Calendar, BookOpen } from 'lucide-react';
import './Faculty.css';

const mockFaculty = [
  { id: 1, name: 'Dr. Sarah Ahmed', designation: 'Professor', department: 'CS', email: 'sarah@university.edu', hireDate: '2015-08-01', courses: 3 },
  { id: 2, name: 'Dr. Ali Raza', designation: 'Associate Professor', department: 'EE', email: 'ali.raza@university.edu', hireDate: '2018-01-15', courses: 2 },
  { id: 3, name: 'Prof. Hassan Khan', designation: 'Professor', department: 'Physics', email: 'hassan@university.edu', hireDate: '2010-09-01', courses: 2 },
  { id: 4, name: 'Dr. Fatima Zahra', designation: 'Assistant Professor', department: 'Math', email: 'fatima@university.edu', hireDate: '2020-08-01', courses: 4 },
  { id: 5, name: 'Mr. Usman Tariq', designation: 'Lecturer', department: 'BBA', email: 'usman@university.edu', hireDate: '2022-01-15', courses: 3 },
];

const Faculty = () => {
  const [selectedFaculty, setSelectedFaculty] = useState(null);

  return (
    <div>
      <PageHeader 
        title="Faculty" 
        description="University academic staff"
        actionText="+ Add Faculty"
      />

      <div className="faculty-grid">
        {mockFaculty.map(faculty => (
          <div key={faculty.id} className="faculty-card glass-card" onClick={() => setSelectedFaculty(faculty)}>
            <div className="faculty-avatar">
              {faculty.name.split(' ').map(n => n[0]).join('').substring(0, 2).replace('.', '')}
            </div>
            <h3 className="faculty-name">{faculty.name}</h3>
            <span className="faculty-designation">{faculty.designation}</span>
            <span className="faculty-dept">{faculty.department}</span>
            
            <div className="faculty-stats">
              <div className="stat">
                <BookOpen size={16} />
                <span>{faculty.courses} Courses</span>
              </div>
            </div>
          </div>
        ))}
      </div>

      <Modal 
        isOpen={!!selectedFaculty}
        onClose={() => setSelectedFaculty(null)}
        title="Faculty Details"
      >
        {selectedFaculty && (
          <div className="faculty-details">
            <div className="detail-header">
              <div className="faculty-avatar large">
                {selectedFaculty.name.split(' ').map(n => n[0]).join('').substring(0, 2).replace('.', '')}
              </div>
              <div>
                <h2>{selectedFaculty.name}</h2>
                <p className="text-gradient">{selectedFaculty.designation}</p>
              </div>
            </div>
            <div className="detail-info">
              <p><Mail size={16}/> {selectedFaculty.email}</p>
              <p><Calendar size={16}/> Joined: {selectedFaculty.hireDate}</p>
              <p><Building2 size={16}/> Department: {selectedFaculty.department}</p>
            </div>
          </div>
        )}
      </Modal>
    </div>
  );
};

// Temp mock for Building2 icon since it wasn't imported in this file
const Building2 = (props) => <svg {...props} xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round"><rect x="4" y="2" width="16" height="20" rx="2" ry="2"/><path d="M9 22v-4h6v4"/><path d="M8 6h.01"/><path d="M16 6h.01"/><path d="M12 6h.01"/><path d="M12 10h.01"/><path d="M12 14h.01"/><path d="M16 10h.01"/><path d="M16 14h.01"/><path d="M8 10h.01"/><path d="M8 14h.01"/></svg>;

export default Faculty;
