import React, { useEffect, useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet } from 'react-native';

export default function App() {
  const [songs, setSongs] = useState([]);
  const [sortedBy, setSortedBy] = useState('');

  useEffect(() => {
    fetchSongs();
  }, []);

  const fetchSongs = async () => {
    try {
      const response = await fetch('https://SongListDemo.api.fake');
      const data = await response.json();
      setSongs(data);
    } catch (error) {
      console.error('Error fetching songs:', error);
    }
  };

  const sortSongs = (sortBy) => {
    let sortedSongs = [...songs].sort((a, b) => {
      if (sortBy === 'title') {
        return a.title.localeCompare(b.title);
      } else if (sortBy === 'number') {
        return a.id - b.id;
      }
    });

    if (sortBy === sortedBy) {
      sortedSongs = sortedSongs.reverse();
    }

    setSortedBy(sortBy);
    setSongs(sortedSongs);
  };

  const renderSongItem = ({ item }) => (
    <TouchableOpacity
      style={styles.songItem}
      onPress={() => toggleSingerVisibility(item)}
      activeOpacity={0.7}
    >
      <Text style={styles.songNumber}>{item.songNumber}</Text>
      <View style={styles.songDetails}>
        <Text style={styles.songTitle}>{item.title}</Text>
        {item.showSinger && <Text style={styles.songSinger}>Singer: {item.artist}</Text>}
      </View>
    </TouchableOpacity>
  );

  const toggleSingerVisibility = (song) => {
    const updatedSongs = songs.map((item) => {
      if (item.id === song.id) {
        return {
          ...item,
          showSinger: !item.showSinger,
        };
      } else {
        return {
          ...item,
          showSinger: false,
        };
      }
    });

    setSongs(updatedSongs);
  };

  return (
    <View style={styles.container}>
      <Text style={styles.headerText}>Song List</Text>
      <FlatList
        data={songs}
        renderItem={renderSongItem}
        keyExtractor={(item) => item.id.toString()}
      />
      <View style={styles.sortButtons}>
        <TouchableOpacity
          style={styles.sortButton}
          onPress={() => sortSongs('title')}
          activeOpacity={0.7}
        >
          <Text style={styles.sortButtonText}>Sort by Title</Text>
        </TouchableOpacity>
        <TouchableOpacity
          style={styles.sortButton}
          onPress={() => sortSongs('number')}
          activeOpacity={0.7}
        >
          <Text style={styles.sortButtonText}>Sort by Number</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    marginTop: 30,
    paddingHorizontal: 16,
    backgroundColor: '#f5f5f5',
  },
  headerText: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#333',
    marginBottom: 16,
  },
  sortButtons: {
    flexDirection: 'row',
    justifyContent: 'flex-end',
    marginBottom: 16,
  },
  sortButton: {
    marginLeft: 10,
    paddingVertical: 6,
    paddingHorizontal: 12,
    backgroundColor: '#ededed',
    borderRadius: 5,
  },
  sortButtonText: {
    fontSize: 16,
    color: '#333',
  },
  songItem: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 10,
    backgroundColor: '#fff',
    paddingVertical: 14,
    paddingHorizontal: 16,
    borderRadius: 8,
    elevation: 2,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowRadius: 4,
    shadowOffset: { width: 0, height: 2 },
  },
  songNumber: {
    fontSize: 16,
    fontWeight: 'bold',
    marginRight: 10,
    color: '#333',
  },
  songDetails: {
    flex: 1,
  },
  songTitle: {
    fontSize: 18,
    color: '#333',
  },
  songSinger: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#777',
    marginTop: 4,
  },
});
