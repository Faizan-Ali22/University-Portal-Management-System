import React from 'react';

const PageHeader = ({ title, description, actionText, onAction }) => {
  return (
    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '2rem' }}>
      <div>
        <h2 className="text-gradient" style={{ margin: 0, fontSize: '1.75rem' }}>{title}</h2>
        {description && <p style={{ color: 'var(--text-muted)', margin: '0.5rem 0 0 0' }}>{description}</p>}
      </div>
      {actionText && (
        <button className="btn-primary" onClick={onAction}>
          {actionText}
        </button>
      )}
    </div>
  );
};

export default PageHeader;
