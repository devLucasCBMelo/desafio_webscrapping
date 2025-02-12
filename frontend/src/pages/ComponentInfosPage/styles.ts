import styled from "styled-components";

export const ComponentInfosPageContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;

  button {
    margin-left: 2px;
    margin-bottom: 30px;
    background-color: #007bff;
    color: white;
    border: none;
    padding: 8px 12px;
    font-size: 14px;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease-in-out;

    &:hover {
      background-color: #0056b3;
    }
  }
`

export const Table = styled.table`
  border-collapse: collapse;
  width: 100%;
  margin-bottom: 30px;

  th {
    border: 1px solid black;
    padding: 8px;
    background-color: #f2f2f2;
  }

  td {
    border: 1px solid black;
    padding: 8px;
  }

  tr {
    &:nth-child(even) {
      background-color: #DAC8B3
    }
  }
`

export const TitleTD = styled.td`
  border: 1px solid black;
  padding: 8px;
  font-weight: bold;
  font-size: 18px;
`