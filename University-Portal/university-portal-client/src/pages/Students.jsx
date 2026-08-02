import React, { useEffect, useState } from 'react';
import PageHeader from '../components/ui/PageHeader';
import DataTable from '../components/ui/DataTable';
import Modal from '../components/ui/Modal';
import { getStudents } from '../api/students';
import toast from 'react-hot-toast';

const Students = () => {
  const [students, setStudents] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modalOpen, setModalOpen] = useState(false);
  const [currentStudent, setCurrentStudent] = useState(null);

  useEffect(() => {
    fetchStudents();
  }, []);

  const fetchStudents = async () => {
    setLoading(true);
    try {
      const data = await getStudents();
      setStudents(data);
    } catch (err) {
      toast.error('Failed to load students');
    } finally {
      setLoading(false);
    }
  };

  const handleAdd = () => {
    setCurrentStudent(null);
    setModalOpen(true);
  };

  const handleEdit = (student) => {
    setCurrentStudent(student);
    setModalOpen(true);
  };

  const handleDelete = (student) => {
    if (window.confirm(`Are you sure you want to delete ${student.name}?`)) {
      setStudents(students.filter(s => s.id !== student.id));
      toast.success('Student deleted successfully');
    }
  };

  const getGpaColor = (gpa) => {
    if (gpa >= 3.5) return 'var(--color-success)';
    if (gpa >= 3.0) return 'var(--color-secondary)';
    if (gpa >= 2.5) return 'var(--color-warning)';
    return 'var(--color-error)';
  };

  const columns = [
    {
      key: 'avatar',
      label: 'Avatar',
      sortable: false,
      render: (_, row) => (
        <div style={{
          width: 32, height: 32, borderRadius: '50%', 
          background: 'var(--color-primary-light)', color: 'white',
          display: 'flex', alignItems: 'center', justifyContent: 'center',
          fontWeight: 'bold', fontSize: '12px'
        }}>
          {(row.name || 'Student').split(' ').filter(Boolean).map(n => n[0]).join('').substring(0, 2)}
        </div>
      )
    },
    { key: 'name', label: 'Name' },
    { key: 'email', label: 'Email' },
    { key: 'department', label: 'Department' },
    { 
      key: 'gpa', 
      label: 'GPA',
      render: (gpa) => (
        <span style={{
          background: `${getGpaColor(gpa || 0)}22`,
          color: getGpaColor(gpa || 0),
          padding: '4px 8px',
          borderRadius: '12px',
          fontWeight: '600',
          fontSize: '0.85rem'
        }}>
          {gpa ? Number(gpa).toFixed(2) : 'N/A'}
        </span>
      )
    },
    { key: 'enrollmentDate', label: 'Enrollment Date' }
  ];

  return (
    <div>
      <PageHeader 
        title="Students" 
        description="Manage university students"
        actionText="+ Add Student"
        onAction={handleAdd}
      />
      
      <DataTable 
        columns={columns}
        data={students}
        loading={loading}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />

      <Modal 
        isOpen={modalOpen} 
        onClose={() => setModalOpen(false)}
        title={currentStudent ? "Edit Student" : "Add New Student"}
        footer={
          <>
            <button className="btn-secondary" onClick={() => setModalOpen(false)}>Cancel</button>
            <button className="btn-primary" onClick={() => {
              toast.success(currentStudent ? 'Student updated' : 'Student added');
              setModalOpen(false);
            }}>Save</button>
          </>
        }
      >
        <form style={{ display: 'flex', flexDirection: 'column', gap: '1rem' }}>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)' }}>Full Name</label>
            <input type="text" defaultValue={currentStudent?.name || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: '8px', border: '1px solid var(--glass-border)', background: 'rgba(0,0,0,0.1)', color: 'var(--text-primary)' }} />
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)' }}>Email</label>
            <input type="email" defaultValue={currentStudent?.email || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: '8px', border: '1px solid var(--glass-border)', background: 'rgba(0,0,0,0.1)', color: 'var(--text-primary)' }} />
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)' }}>Department</label>
            <select defaultValue={currentStudent?.department || 'CS'} style={{ width: '100%', padding: '0.75rem', borderRadius: '8px', border: '1px solid var(--glass-border)', background: 'rgba(0,0,0,0.1)', color: 'var(--text-primary)' }}>
              <option value="CS">Computer Science</option>
              <option value="EE">Electrical Engineering</option>
              <option value="BBA">Business Administration</option>
              <option value="Math">Mathematics</option>
              <option value="Physics">Physics</option>
            </select>
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)' }}>GPA</label>
            <input type="number" step="0.1" max="4.0" min="0" defaultValue={currentStudent?.gpa || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: '8px', border: '1px solid var(--glass-border)', background: 'rgba(0,0,0,0.1)', color: 'var(--text-primary)' }} />
          </div>
        </form>
      </Modal>
    </div>
  );
};

export default Students;
