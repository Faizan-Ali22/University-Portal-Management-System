import React, { useState } from 'react';
import { Outlet } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import Sidebar from './Sidebar';
import TopBar from './TopBar';
import './AppLayout.css';

const AppLayout = () => {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <div className="app-layout">
      <Sidebar collapsed={collapsed} setCollapsed={setCollapsed} />
      <div className={`main-wrapper ${collapsed ? 'expanded' : ''}`}>
        <TopBar collapsed={collapsed} />
        <main className="main-content">
          <AnimatePresence mode="wait">
            <motion.div
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              exit={{ opacity: 0, y: -20 }}
              transition={{ duration: 0.3 }}
              style={{ width: '100%', height: '100%' }}
            >
              <Outlet />
            </motion.div>
          </AnimatePresence>
        </main>
      </div>
    </div>
  );
};

export default AppLayout;
