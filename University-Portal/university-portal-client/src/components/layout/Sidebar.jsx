import React, { useState } from 'react';
import { NavLink, useLocation } from 'react-router-dom';
import { 
  LayoutDashboard, Users, BookOpen, GraduationCap, Building2, UserPlus, 
  ClipboardCheck, FileText, Award, Calendar, Megaphone, User, ChevronLeft, ChevronRight 
} from 'lucide-react';
import './Sidebar.css';

const navItems = [
  { title: 'MAIN', items: [{ path: '/', icon: LayoutDashboard, label: 'Dashboard' }] },
  { title: 'ACADEMIC', items: [
    { path: '/students', icon: Users, label: 'Students' },
    { path: '/courses', icon: BookOpen, label: 'Courses' },
    { path: '/faculty', icon: GraduationCap, label: 'Faculty' },
    { path: '/departments', icon: Building2, label: 'Departments' }
  ]},
  { title: 'MANAGEMENT', items: [
    { path: '/enrollments', icon: UserPlus, label: 'Enrollments' },
    { path: '/attendance', icon: ClipboardCheck, label: 'Attendance' },
    { path: '/exams', icon: FileText, label: 'Exams' },
    { path: '/grades', icon: Award, label: 'Grades' }
  ]},
  { title: 'OTHER', items: [
    { path: '/timetable', icon: Calendar, label: 'Timetable' },
    { path: '/announcements', icon: Megaphone, label: 'Announcements' }
  ]}
];

const Sidebar = ({ collapsed, setCollapsed }) => {
  const location = useLocation();

  return (
    <aside className={`sidebar glass-card ${collapsed ? 'collapsed' : ''}`}>
      <div className="sidebar-header">
        <div className="logo-container">
          <GraduationCap className="logo-icon" />
          {!collapsed && <span className="logo-text text-gradient">UniPortal</span>}
        </div>
      </div>
      
      <div className="sidebar-content">
        {navItems.map((section, idx) => (
          <div key={idx} className="nav-section">
            {!collapsed && <div className="nav-section-title">{section.title}</div>}
            <div className="nav-items">
              {section.items.map((item, i) => {
                const Icon = item.icon;
                const isActive = location.pathname === item.path;
                return (
                  <NavLink 
                    key={i} 
                    to={item.path} 
                    className={`nav-item ${isActive ? 'active' : ''}`}
                    title={collapsed ? item.label : ''}
                  >
                    <Icon className="nav-icon" />
                    {!collapsed && <span className="nav-label">{item.label}</span>}
                    {isActive && !collapsed && <div className="active-indicator" />}
                  </NavLink>
                );
              })}
            </div>
          </div>
        ))}
      </div>

      <div className="sidebar-footer">
        <button className="collapse-btn" onClick={() => setCollapsed(!collapsed)}>
          {collapsed ? <ChevronRight /> : <ChevronLeft />}
        </button>
      </div>
    </aside>
  );
};

export default Sidebar;
