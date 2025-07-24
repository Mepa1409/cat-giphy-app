import React, { useEffect, useState } from "react";
import { fetchHistory, HistoryRecord } from "../services/historyService";

const HistoryPage: React.FC = () => {
  const [history, setHistory] = useState<HistoryRecord[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadHistory = async () => {
      try {
        const data = await fetchHistory();
        setHistory(data);
      } catch (error) {
        console.error("Error cargando historial:", error);
      } finally {
        setLoading(false);
      }
    };

    loadHistory();
  }, []);

  if (loading) {
    return <p style={styles.message}>Cargando historial...</p>;
  }

  if (history.length === 0) {
    return <p style={styles.message}>No hay búsquedas registradas.</p>;
  }

  return (
    <div style={styles.container}>
      <h2 style={styles.title}>Historial de Búsquedas</h2>
      <div style={{ overflowX: "auto" }}>
        <table style={styles.table}>
          <thead>
            <tr>
              <th style={styles.th}>Fecha</th>
              <th style={styles.th}>Cat Fact</th>
              <th style={styles.th}>Query</th>
              <th style={styles.th}>GIF</th>
            </tr>
          </thead>
          <tbody>
            {history.map((record, index) => (
              <tr
                key={index}
                style={index % 2 === 0 ? styles.row : styles.altRow}
              >
                <td style={styles.td}>
                  {new Date(record.date).toLocaleString("es-CO")}
                </td>
                <td style={styles.td}>{record.fact}</td>
                <td style={styles.td}>
                  <span style={styles.query}>{record.queryWords}</span>
                </td>
                <td style={styles.td}>
                  <a
                    href={record.gifUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    style={styles.link}
                  >
                    Ver GIF
                  </a>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

const styles = {
  container: {
    marginTop: "2rem",
    backgroundColor: "#ffffff",
    padding: "2rem",
    borderRadius: "12px",
    boxShadow: "0 4px 20px rgba(0,0,0,0.08)",
  },
  title: {
    textAlign: "center" as const,
    marginBottom: "1.5rem",
    fontSize: "1.4rem",
    fontWeight: 600,
    color: "#333",
  },
  table: {
    width: "100%",
    borderCollapse: "collapse" as const,
    fontSize: "0.95rem",
    minWidth: "600px",
  },
  th: {
    textAlign: "left" as const,
    padding: "12px 16px",
    backgroundColor: "#f4f4f4",
    borderBottom: "2px solid #ddd",
    fontWeight: 600,
    color: "#333",
  },
  td: {
    padding: "12px 16px",
    borderBottom: "1px solid #e0e0e0",
    verticalAlign: "top" as const,
    color: "#444",
  },
  row: {
    backgroundColor: "#fff",
  },
  altRow: {
    backgroundColor: "#f9f9f9",
  },
  link: {
    color: "#1e90ff",
    textDecoration: "none",
    fontWeight: 500,
  },
  query: {
    fontFamily: "monospace",
    backgroundColor: "#eef2f6",
    padding: "4px 6px",
    borderRadius: "4px",
    fontSize: "0.9rem",
  },
  message: {
    textAlign: "center" as const,
    marginTop: "2rem",
    fontSize: "1rem",
    color: "#666",
  },
};

export default HistoryPage;
