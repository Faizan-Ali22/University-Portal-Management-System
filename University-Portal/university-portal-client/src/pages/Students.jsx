import React, { useEffect, useState } from 'react';
import PageHeader from '../components/ui/PageHeader';
import DataTable from '../components/ui/DataTable';
import Modal from '../components/ui/Modal';
import { getStudents } from '../api/students';
import toast from 'react-hot-toast';

export default function Students() {
  const [students, setStudents] = useState([]);
  const [loading, setLoading] = useState(true);
  const [modalOpen, setModalOpen] = useState(false);
  const [currentStudent, setCurrentStudent] = useState(null);

  useEffect(() => {
    async function fetchStudents() {
      setLoading(true);
      try {
        const data = await getStudents();
        setStudents(data || []);
      } catch (err) {
        toast.error('Failed to load students');
      } finally {
        setLoading(false);
      }
    }
    fetchStudents();
  }, []);

  const handleAdd = () => {
    setCurrentStudent(null);
    setModalOpen(true);
  };

  const handleEdit = (student) => {
    setCurrentStudent(student);
    setModalOpen(true);
  };

  const handleDelete = (student) => {
    if (window.confirm(`Delete student ${student?.name || ''}?`)) {
      setStudents(prev => prev.filter(s => s.id !== student.id));
      toast.success('Student deleted');
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
      render: (_, row) => {
        const name = row?.name || 'Student';
        const initials = name.split(' ').filter(Boolean).map(n => n[0]).join('').substring(0, 2);
        return (
          <div style={{
            width: 32, height: 32, borderRadius: 'var(--border-radius-sm)', 
            background: 'var(--bg-card-hover)', color: 'var(--color-primary)',
            display: 'flex', alignItems: 'center', justifyContent: 'center',
            fontWeight: '500', fontSize: '11px', border: '1px solid var(--glass-border)'
          }}>
            {initials}
          </div>
        );
      }
    },
    { key: 'name', label: 'Name' },
    { key: 'email', label: 'Email' },
    { key: 'department', label: 'Department' },
    { 
      key: 'gpa', 
      label: 'GPA',
      render: (gpa) => (
        <span style={{
          color: getGpaColor(gpa || 0),
          fontWeight: '500',
          fontSize: '0.85rem'
        }}>
          {gpa ? Number(gpa).toFixed(2) : 'N/A'}
        </span>
      )
    },
    { key: 'enrollmentDate', label: 'Enrollment' }
  ];

  return (
    <div>
      <PageHeader 
        title="Students" 
        description="Manage records"
        actionText="Add Student"
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
        title={currentStudent ? "Edit Student" : "New Student"}
        footer={
          <div style={{ display: 'flex', gap: '1rem', width: '100%', justifyContent: 'flex-end' }}>
            <button className="btn-secondary" onClick={() => setModalOpen(false)}>Cancel</button>
            <button className="btn-primary" onClick={() => {
              toast.success(currentStudent ? 'Updated successfully' : 'Created successfully');
              setModalOpen(false);
            }}>Save</button>
          </div>
        }
      >
        <form style={{ display: 'flex', flexDirection: 'column', gap: '1.25rem' }}>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)', fontSize: '0.85rem' }}>Full Name</label>
            <input type="text" defaultValue={currentStudent?.name || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: 'var(--border-radius-sm)', border: '1px solid var(--glass-border)', background: 'transparent', color: 'var(--text-primary)' }} />
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)', fontSize: '0.85rem' }}>Email</label>
            <input type="email" defaultValue={currentStudent?.email || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: 'var(--border-radius-sm)', border: '1px solid var(--glass-border)', background: 'transparent', color: 'var(--text-primary)' }} />
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)', fontSize: '0.85rem' }}>Department</label>
            <select defaultValue={currentStudent?.department || 'CS'} style={{ width: '100%', padding: '0.75rem', borderRadius: 'var(--border-radius-sm)', border: '1px solid var(--glass-border)', background: 'var(--bg-primary)', color: 'var(--text-primary)' }}>
              <option value="CS">Computer Science</option>
              <option value="EE">Electrical Engineering</option>
              <option value="BBA">Business Administration</option>
              <option value="Math">Mathematics</option>
              <option value="Physics">Physics</option>
            </select>
          </div>
          <div>
            <label style={{ display: 'block', marginBottom: '0.5rem', color: 'var(--text-secondary)', fontSize: '0.85rem' }}>GPA</label>
            <input type="number" step="0.1" max="4.0" min="0" defaultValue={currentStudent?.gpa || ''} style={{ width: '100%', padding: '0.75rem', borderRadius: 'var(--border-radius-sm)', border: '1px solid var(--glass-border)', background: 'transparent', color: 'var(--text-primary)' }} />
          </div>
        </form>
      </Modal>
    </div>
  );
}
