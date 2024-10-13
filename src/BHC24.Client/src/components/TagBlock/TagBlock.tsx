import { GetTagResponse } from "../../utils/models";

export const TagBlock = ({ tag }: { tag: GetTagResponse }) => (
  <div style={{
    width: '5rem',
    height: '5rem',
    padding: '0.5rem',
    backgroundColor: 'white',
    borderRadius: '15%',
    cursor: 'pointer',
    userSelect: 'none',
    
  }}>
    <img src={'/' + tag.imagePath} draggable='false' style={{ width: '100%', height: '100%' }} />
  </div>
);