import React from 'react';
import { PackageOpen } from 'lucide-react';

const EmptyState = ({ icon: Icon = PackageOpen, message = "No data available", action }) => {
  return (
    <div style={{ padding: '3rem', textAlign: 'center', color: 'var(--text-muted)', display: 'flex', flexDirection: 'column', alignItems: 'center', gap: '1rem' }}>
      <Icon size={48} style={{ opacity: 0.5 }} />
      <p style={{ margin: 0 }}>{message}</p>
      {action}
    </div>
  );
};

export default EmptyState;
