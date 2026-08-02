import React, { useEffect, useState } from 'react';
import { Users, BookOpen, GraduationCap, Building2, UserPlus, Bell } from 'lucide-react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, PieChart, Pie, Cell, BarChart, Bar } from 'recharts';
import StatCard from '../components/ui/StatCard';
import { getDashboardStats } from '../api/dashboard';
import './Dashboard.css';

const enrollmentData = [
  { name: 'Jan', enrollments: 120 },
  { name: 'Feb', enrollments: 180 },
  { name: 'Mar', enrollments: 150 },
  { name: 'Apr', enrollments: 250 },
  { name: 'May', enrollments: 220 },
  { name: 'Jun', enrollments: 312 },
];

const deptData = [
  { name: 'CS', value: 400, color: '#7c3aed' },
  { name: 'EE', value: 300, color: '#06b6d4' },
  { name: 'BBA', value: 300, color: '#10b981' },
  { name: 'Math', value: 200, color: '#f59e0b' },
  { name: 'Physics', value: 150, color: '#ef4444' },
];

const popularCourses = [
  { name: 'CS101', students: 120 },
  { name: 'MATH101', students: 95 },
  { name: 'PHY101', students: 85 },
  { name: 'BBA101', students: 70 },
  { name: 'EE101', students: 65 },
];

const Dashboard = () => {
  const [stats, setStats] = useState(null);

  useEffect(() => {
    getDashboardStats().then(setStats);
  }, []);

  return (
    <div className="dashboard">
      <div className="stats-grid">
        <StatCard title="Total Students" value={stats?.totalStudents || 0} icon={Users} trend={5} colorClass="primary" />
        <StatCard title="Total Courses" value={stats?.totalCourses || 0} icon={BookOpen} trend={2} colorClass="secondary" />
        <StatCard title="Total Faculty" value={stats?.totalFaculty || 0} icon={GraduationCap} colorClass="success" />
        <StatCard title="Departments" value={stats?.totalDepartments || 0} icon={Building2} colorClass="warning" />
        <StatCard title="Active Enrollments" value={stats?.activeEnrollments || 0} icon={UserPlus} trend={12} colorClass="error" />
      </div>

      <div className="charts-grid-2">
        <div className="chart-card glass-card">
          <h3>Enrollment Trends</h3>
          <div className="chart-container">
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={enrollmentData} margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
                <defs>
                  <linearGradient id="colorEnroll" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="var(--color-primary)" stopOpacity={0.8}/>
                    <stop offset="95%" stopColor="var(--color-primary)" stopOpacity={0}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--glass-border)" vertical={false} />
                <XAxis dataKey="name" stroke="var(--text-muted)" />
                <YAxis stroke="var(--text-muted)" />
                <Tooltip 
                  contentStyle={{ backgroundColor: 'var(--bg-secondary)', border: '1px solid var(--glass-border)', borderRadius: '8px' }}
                  itemStyle={{ color: 'var(--text-primary)' }}
                />
                <Area type="monotone" dataKey="enrollments" stroke="var(--color-primary)" fillOpacity={1} fill="url(#colorEnroll)" />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="chart-card glass-card">
          <h3>Students by Department</h3>
          <div className="chart-container">
            <ResponsiveContainer width="100%" height="100%">
              <PieChart>
                <Pie data={deptData} cx="50%" cy="50%" innerRadius={60} outerRadius={80} paddingAngle={5} dataKey="value">
                  {deptData.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={entry.color} />
                  ))}
                </Pie>
                <Tooltip contentStyle={{ backgroundColor: 'var(--bg-secondary)', border: 'none', borderRadius: '8px' }} />
              </PieChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>

      <div className="charts-grid-2">
        <div className="chart-card glass-card">
          <h3>Course Popularity</h3>
          <div className="chart-container">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart data={popularCourses} margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--glass-border)" vertical={false} />
                <XAxis dataKey="name" stroke="var(--text-muted)" />
                <YAxis stroke="var(--text-muted)" />
                <Tooltip contentStyle={{ backgroundColor: 'var(--bg-secondary)', border: 'none', borderRadius: '8px' }} cursor={{fill: 'var(--bg-card-hover)'}}/>
                <Bar dataKey="students" fill="var(--color-secondary)" radius={[4, 4, 0, 0]} />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="chart-card glass-card">
          <h3>Recent Announcements</h3>
          <div className="announcements-list">
            {[1,2,3,4].map(i => (
              <div key={i} className="announcement-item">
                <div className="announcement-icon">
                  <Bell size={18} />
                </div>
                <div className="announcement-content">
                  <h4>Midterm Schedule Released</h4>
                  <p>Check the timetable for your respective courses.</p>
                </div>
                <span className="announcement-time">2h ago</span>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default Dashboard;
