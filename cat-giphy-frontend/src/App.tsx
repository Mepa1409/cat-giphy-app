import React, { useState } from 'react';
import Tabs from './components/Tabs';
import ActualFactPage from './pages/ActualFactPage';
import HistoryPage from './pages/HistoryPage';

function App() {
  const [activeTab, setActiveTab] = useState<'actual' | 'historial'>('actual');

  return (
    <div style={{ padding: '2rem', maxWidth: '800px', margin: '0 auto' }}>
      <h1 style={{ textAlign: 'center' }}>🐱 Cat Giphy App</h1>
      <Tabs activeTab={activeTab} onTabChange={setActiveTab} />
      {activeTab === 'actual' ? <ActualFactPage /> : <HistoryPage />}
    </div>
  );
}

export default App;
