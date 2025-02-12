import styled from "styled-components";

export const ComponentInfosPageContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;

  div {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 30px;


    h2 {
      margin-bottom: 10px;
    }

    p {
      margin: 5px 5px;
    }

   button {
      margin-top: 10px;
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
  }

  @media (max-width: 500px) {
    div {
      h2 {
        font-size: 20px;
      }
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

  @media (max-width: 500px) {
    width: 97%;
  }
`

export const TitleTD = styled.td`
  border: 1px solid black;
  padding: 8px;
  font-weight: bold;
  font-size: 18px;
`