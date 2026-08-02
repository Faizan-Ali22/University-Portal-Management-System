import React from 'react';
import { useLocation } from 'react-router-dom';
import { Search, Bell, Sun, Moon, LogOut, Settings, User as UserIcon } from 'lucide-react';
import { useTheme } from '../../context/ThemeContext';
import { useAuth } from '../../context/AuthContext';
import './TopBar.css';

const TopBar = ({ collapsed }) => {
  const { theme, toggleTheme } = useTheme();
  const { user, logout } = useAuth();
  const location = useLocation();

  const getPageTitle = () => {
    const path = location.pathname;
    if (path === '/') return 'Dashboard';
    const segment = path.split('/')[1];
    return segment.charAt(0).toUpperCase() + segment.slice(1);
  };

  return (
    <header className={`topbar glass-card ${collapsed ? 'expanded' : ''}`}>
      <div className="topbar-left">
        <h1 className="page-title text-gradient">{getPageTitle()}</h1>
      </div>
      
      <div className="topbar-center">
        <div className="search-container glass-card">
          <Search className="search-icon" size={18} />
          <input type="text" placeholder="Search..." className="search-input" />
        </div>
      </div>

      <div className="topbar-right">
        <button className="icon-btn" onClick={toggleTheme}>
          {theme === 'dark' ? <Sun size={20} /> : <Moon size={20} />}
        </button>
        <button className="icon-btn notification-btn">
          <Bell size={20} />
          <span className="badge">3</span>
        </button>
        <div className="user-profile">
          <img src={user?.avatar || `https://ui-avatars.com/api/?name=${user?.name || 'User'}`} alt="avatar" className="avatar" />
          <div className="user-info">
            <span className="user-name">{user?.name}</span>
            <span className="user-role">{user?.role}</span>
          </div>
          <button className="icon-btn" onClick={logout} title="Logout">
            <LogOut size={18} />
          </button>
        </div>
      </div>
    </header>
  );
};

export default TopBar;
