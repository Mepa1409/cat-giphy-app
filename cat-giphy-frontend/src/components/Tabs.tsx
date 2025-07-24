import React from 'react';

interface TabsProps {
  activeTab: 'actual' | 'historial';
  onTabChange: (tab: 'actual' | 'historial') => void;
}

const Tabs: React.FC<TabsProps> = ({ activeTab, onTabChange }) => {
  return (
    <div style={{ display: 'flex', justifyContent: 'center', gap: '1rem', marginBottom: '1rem' }}>
      <button
        onClick={() => onTabChange('actual')}
        style={{
          padding: '10px 20px',
          backgroundColor: activeTab === 'actual' ? '#4CAF50' : '#f1f1f1',
          color: activeTab === 'actual' ? 'white' : 'black',
          border: 'none',
          cursor: 'pointer',
          borderRadius: '5px',
        }}
      >
        Resultado actual
      </button>
      <button
        onClick={() => onTabChange('historial')}
        style={{
          padding: '10px 20px',
          backgroundColor: activeTab === 'historial' ? '#4CAF50' : '#f1f1f1',
          color: activeTab === 'historial' ? 'white' : 'black',
          border: 'none',
          cursor: 'pointer',
          borderRadius: '5px',
        }}
      >
        Historial
      </button>
    </div>
  );
};

export default Tabs;
