import React, { useEffect, useState } from 'react';
import { Bell, ArrowRight } from 'lucide-react';
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import { getDashboardStats } from '../api/dashboard';
import toast from 'react-hot-toast';
import './Dashboard.css';

const enrollmentData = [
  { name: 'Jan', enrollments: 120 },
  { name: 'Feb', enrollments: 180 },
  { name: 'Mar', enrollments: 150 },
  { name: 'Apr', enrollments: 250 },
  { name: 'May', enrollments: 220 },
  { name: 'Jun', enrollments: 312 },
];

const Dashboard = () => {
  const [stats, setStats] = useState(null);

  useEffect(() => {
    getDashboardStats().then(setStats);
  }, []);

  return (
    <div className="dashboard-minimal">
      <header className="dashboard-hero">
        <div className="hero-content">
          <h1 className="text-gradient">Welcome back.</h1>
          <p className="hero-subtitle">University overview and key insights.</p>
        </div>
        <div className="hero-stats">
          <div className="stat-pill">
            <span className="stat-label">Total Students</span>
            <span className="stat-val">{stats?.totalStudents || '...'}</span>
          </div>
          <div className="stat-pill">
            <span className="stat-label">Active Courses</span>
            <span className="stat-val">{stats?.totalCourses || '...'}</span>
          </div>
        </div>
      </header>

      <section className="insight-section">
        <div className="chart-hero glass-card">
          <div className="chart-hero-header">
            <h3>Enrollment Growth</h3>
            <button className="btn-text" onClick={() => toast.success('Report downloading...')}>View Report <ArrowRight size={16}/></button>
          </div>
          <div className="chart-hero-body" style={{ height: 300 }}>
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart data={enrollmentData} margin={{ top: 20, right: 0, left: 0, bottom: 0 }}>
                <defs>
                  <linearGradient id="colorEnroll" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="var(--color-primary)" stopOpacity={0.4}/>
                    <stop offset="100%" stopColor="var(--color-primary)" stopOpacity={0}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="var(--glass-border)" vertical={false} />
                <XAxis dataKey="name" stroke="var(--text-muted)" axisLine={false} tickLine={false} />
                <YAxis stroke="var(--text-muted)" axisLine={false} tickLine={false} />
                <Tooltip 
                  contentStyle={{ backgroundColor: 'var(--bg-secondary)', border: '1px solid var(--glass-border)', borderRadius: '4px' }}
                  itemStyle={{ color: 'var(--text-primary)' }}
                />
                <Area type="monotone" dataKey="enrollments" stroke="var(--color-primary)" strokeWidth={2} fillOpacity={1} fill="url(#colorEnroll)" />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>

        <div className="feed-hero glass-card">
          <h3>Updates</h3>
          <div className="minimal-feed">
            {[
              { title: 'Midterm Schedule Released', time: '2h ago' },
              { title: 'New Faculty Orientation', time: '5h ago' },
              { title: 'System Maintenance', time: '1d ago' },
            ].map((item, i) => (
              <div key={i} className="feed-item">
                <div className="feed-dot" />
                <div className="feed-content">
                  <h4>{item.title}</h4>
                  <span>{item.time}</span>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>
    </div>
  );
};

export default Dashboard;
