import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { motion } from 'framer-motion';
import { GraduationCap } from 'lucide-react';
import { useAuth } from '../context/AuthContext';
import toast from 'react-hot-toast';
import './Login.css';

const Login = () => {
  const [email, setEmail] = useState('admin@university.edu');
  const [password, setPassword] = useState('Admin123!');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    try {
      await login(email, password);
      toast.success('Welcome back!');
      navigate('/');
    } catch (err) {
      setError('Invalid credentials');
      toast.error('Login failed');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="login-container">
      <div className="animated-background"></div>
      <motion.div 
        className="login-card glass-card"
        initial={{ scale: 0.9, opacity: 0 }}
        animate={{ scale: 1, opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        <div className="login-header">
          <GraduationCap size={48} className="text-gradient" />
          <h2 className="text-gradient">University Portal</h2>
          <p>Sign in to access your dashboard</p>
        </div>

        <form onSubmit={handleSubmit} className="login-form">
          <div className="input-group">
            <input 
              type="email" 
              required 
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Email address"
            />
          </div>
          <div className="input-group">
            <input 
              type="password" 
              required 
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Password"
            />
          </div>
          
          {error && (
            <motion.div 
              className="error-message"
              initial={{ x: -10 }}
              animate={{ x: [0, -10, 10, -10, 10, 0] }}
              transition={{ duration: 0.5 }}
            >
              {error}
            </motion.div>
          )}

          <button type="submit" className="btn-primary login-btn" disabled={loading}>
            {loading ? 'Signing in...' : 'Sign In'}
          </button>
          
          <div className="hint">
            Demo: admin@university.edu / Admin123!
          </div>
        </form>
      </motion.div>
    </div>
  );
};

export default Login;
