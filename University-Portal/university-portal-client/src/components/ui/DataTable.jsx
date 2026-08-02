import React, { useState } from 'react';
import { Search, ChevronUp, ChevronDown, Edit, Trash2 } from 'lucide-react';
import './DataTable.css';
import Skeleton from './Skeleton';
import EmptyState from './EmptyState';

const DataTable = ({ columns, data, loading, onEdit, onDelete }) => {
  const [searchTerm, setSearchTerm] = useState('');
  const [sortConfig, setSortConfig] = useState(null);
  
  if (loading) {
    return (
      <div className="datatable-container glass-card">
        {[1,2,3,4,5].map(i => <Skeleton key={i} variant="table-row" />)}
      </div>
    );
  }

  if (!data || data.length === 0) {
    return (
      <div className="datatable-container glass-card">
        <EmptyState message="No records found" />
      </div>
    );
  }

  const handleSort = (key) => {
    let direction = 'ascending';
    if (sortConfig && sortConfig.key === key && sortConfig.direction === 'ascending') {
      direction = 'descending';
    }
    setSortConfig({ key, direction });
  };

  const sortedData = React.useMemo(() => {
    let sortableItems = [...data];
    if (searchTerm) {
      sortableItems = sortableItems.filter(item => 
        Object.values(item).some(val => 
          String(val).toLowerCase().includes(searchTerm.toLowerCase())
        )
      );
    }
    if (sortConfig !== null) {
      sortableItems.sort((a, b) => {
        if (a[sortConfig.key] < b[sortConfig.key]) {
          return sortConfig.direction === 'ascending' ? -1 : 1;
        }
        if (a[sortConfig.key] > b[sortConfig.key]) {
          return sortConfig.direction === 'ascending' ? 1 : -1;
        }
        return 0;
      });
    }
    return sortableItems;
  }, [data, sortConfig, searchTerm]);

  return (
    <div className="datatable-container glass-card">
      <div className="datatable-header">
        <div className="search-box">
          <Search size={18} />
          <input 
            type="text" 
            placeholder="Search in table..." 
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
        </div>
      </div>
      
      <div className="table-responsive">
        <table className="datatable">
          <thead>
            <tr>
              {columns.map(col => (
                <th key={col.key} onClick={() => col.sortable !== false && handleSort(col.key)} className={col.sortable !== false ? 'sortable' : ''}>
                  <div className="th-content">
                    {col.label}
                    {col.sortable !== false && sortConfig?.key === col.key && (
                      sortConfig.direction === 'ascending' ? <ChevronUp size={14} /> : <ChevronDown size={14} />
                    )}
                  </div>
                </th>
              ))}
              {(onEdit || onDelete) && <th>Actions</th>}
            </tr>
          </thead>
          <tbody>
            {sortedData.map((row, i) => (
              <tr key={row.id || i}>
                {columns.map(col => (
                  <td key={col.key}>
                    {col.render ? col.render(row[col.key], row) : row[col.key]}
                  </td>
                ))}
                {(onEdit || onDelete) && (
                  <td>
                    <div className="action-buttons">
                      {onEdit && (
                        <button className="btn-action edit" onClick={() => onEdit(row)}>
                          <Edit size={16} />
                        </button>
                      )}
                      {onDelete && (
                        <button className="btn-action delete" onClick={() => onDelete(row)}>
                          <Trash2 size={16} />
                        </button>
                      )}
                    </div>
                  </td>
                )}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      
      <div className="datatable-footer">
        Showing {sortedData.length} records
      </div>
    </div>
  );
};

export default DataTable;
