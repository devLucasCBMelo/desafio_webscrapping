import styled from "styled-components";

export const ComponentInfosPageContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
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
      background-color: #f9f9f9
    }
  }
`