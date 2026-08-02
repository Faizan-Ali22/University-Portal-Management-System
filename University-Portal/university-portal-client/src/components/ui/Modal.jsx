import React from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import { X } from 'lucide-react';
import './Modal.css';

const Modal = ({ isOpen, onClose, title, children, footer }) => {
  if (!isOpen) return null;

  return (
    <AnimatePresence>
      <div className="modal-backdrop" onClick={onClose}>
        <motion.div 
          className="modal-content glass-card"
          initial={{ scale: 0.9, opacity: 0 }}
          animate={{ scale: 1, opacity: 1 }}
          exit={{ scale: 0.9, opacity: 0 }}
          transition={{ type: 'spring', damping: 25, stiffness: 300 }}
          onClick={e => e.stopPropagation()}
        >
          <div className="modal-header">
            <h3>{title}</h3>
            <button className="close-btn" onClick={onClose}><X size={20} /></button>
          </div>
          <div className="modal-body">
            {children}
          </div>
          {footer && (
            <div className="modal-footer">
              {footer}
            </div>
          )}
        </motion.div>
      </div>
    </AnimatePresence>
  );
};

export default Modal;
