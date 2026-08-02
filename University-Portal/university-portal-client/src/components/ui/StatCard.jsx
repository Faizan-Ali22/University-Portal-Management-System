import React, { useEffect, useState } from 'react';
import { ArrowUpRight, ArrowDownRight } from 'lucide-react';
import './StatCard.css';

const StatCard = ({ title, value, icon: Icon, trend, colorClass }) => {
  const [count, setCount] = useState(0);

  useEffect(() => {
    let start = 0;
    const duration = 1000;
    const target = parseInt(value.toString().replace(/,/g, ''));
    if (isNaN(target)) {
      setCount(value);
      return;
    }
    const increment = target / (duration / 16);
    
    const timer = setInterval(() => {
      start += increment;
      if (start >= target) {
        setCount(target);
        clearInterval(timer);
      } else {
        setCount(Math.floor(start));
      }
    }, 16);
    
    return () => clearInterval(timer);
  }, [value]);

  return (
    <div className="stat-card glass-card">
      <div className="stat-header">
        <div className={`icon-wrapper ${colorClass}`}>
          <Icon size={24} />
        </div>
        {trend && (
          <div className={`trend-indicator ${trend > 0 ? 'positive' : 'negative'}`}>
            {trend > 0 ? <ArrowUpRight size={16} /> : <ArrowDownRight size={16} />}
            <span>{Math.abs(trend)}%</span>
          </div>
        )}
      </div>
      <div className="stat-content">
        <h3 className="stat-value">{count.toLocaleString()}</h3>
        <p className="stat-title">{title}</p>
      </div>
    </div>
  );
};

export default StatCard;
