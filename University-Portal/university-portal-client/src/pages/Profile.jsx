import React from 'react';
import { useAuth } from '../context/AuthContext';
import { useTheme } from '../context/ThemeContext';
import PageHeader from '../components/ui/PageHeader';
import { User, Mail, Shield, Bell, Moon, Sun, Monitor } from 'lucide-react';
import './Profile.css';

const Profile = () => {
  const { user } = useAuth();
  const { theme, toggleTheme } = useTheme();

  return (
    <div className="profile-page">
      <PageHeader title="Profile Settings" />
      
      <div className="profile-grid">
        <div className="profile-card glass-card">
          <div className="profile-cover"></div>
          <div className="profile-info-wrapper">
            <img src={user?.avatar} alt="User Avatar" className="profile-avatar-large" />
            <h2 className="profile-name">{user?.name}</h2>
            <p className="profile-role text-gradient">{user?.role}</p>
            
            <div className="profile-details-list">
              <div className="detail-item">
                <Mail size={18} />
                <span>{user?.email}</span>
              </div>
              <div className="detail-item">
                <Shield size={18} />
                <span>Administrator Access</span>
              </div>
            </div>
          </div>
        </div>

        <div className="settings-container">
          <div className="settings-card glass-card">
            <h3>Appearance</h3>
            <div className="setting-item">
              <div className="setting-info">
                <div className="setting-icon">
                  {theme === 'dark' ? <Moon size={20}/> : <Sun size={20}/>}
                </div>
                <div>
                  <h4>Theme Preference</h4>
                  <p>Toggle between light and dark mode</p>
                </div>
              </div>
              <button className="btn-secondary" onClick={toggleTheme}>
                Switch to {theme === 'dark' ? 'Light' : 'Dark'}
              </button>
            </div>
          </div>

          <div className="settings-card glass-card">
            <h3>Notifications</h3>
            <div className="setting-item">
              <div className="setting-info">
                <div className="setting-icon"><Bell size={20}/></div>
                <div>
                  <h4>Email Notifications</h4>
                  <p>Receive updates about system activity</p>
                </div>
              </div>
              <label className="toggle-switch">
                <input type="checkbox" defaultChecked />
                <span className="slider"></span>
              </label>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Profile;
